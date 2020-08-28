using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromJson;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitchXml.FromStudioOneKeySwitch;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;
using ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml;

namespace ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromJson
{
    public class ConvertingToStudioOneKeySwitchFileInteractor : IFileConvertingInteractor<JsonRoot, RootElement>
    {
        public IFileRepository<JsonRoot> SourceRepository { get; }

        public IFileRepository<RootElement> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        public ConvertingToStudioOneKeySwitchFileInteractor(
            IFileRepository<JsonRoot> loadRepository,
            IFileRepository<RootElement> saveRepository,
            ITextPresenter presenter )
        {
            SourceRepository = loadRepository;
            TargetRepository = saveRepository;
            Presenter        = presenter;
        }

        public void Convert( IFileConvertingRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var json = SourceRepository.Load();
            var jsonTranslator = new JsonTranslator();
            var keySwitchTranslator = new StudioOneKeySwitchTranslator();

            foreach( var keySwitch in jsonTranslator.Translate( json ) )
            {
                foreach( var xml in keySwitchTranslator.Translate( keySwitch ) )
                {
                    Presenter.Progress( keySwitch.Name.Value );

                    TargetRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        keySwitch.Name.Value + TargetRepository.Suffix
                    );
                    TargetRepository.Save( xml );
                }
            }
        }
    }
}