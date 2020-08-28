using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitchXml.FromStudioOneKeySwitch;
using ArticulationUtility.UseCases.Converting;

using ExpressionMapRootElement = ArticulationUtility.UseCases.Values.VSTExpressionMapXml.RootElement;
using StudioOneRootElement = ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml.RootElement;

namespace ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromVSTExpressionMap
{
    public class ConvertingToStudioOneKeySwitchFileInteractor : IFileConvertingInteractor<ExpressionMapRootElement, StudioOneRootElement>
    {
        public IFileRepository<ExpressionMapRootElement> SourceRepository { get; }

        public IFileRepository<StudioOneRootElement> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        public ConvertingToStudioOneKeySwitchFileInteractor(
            IFileRepository<ExpressionMapRootElement> loadRepository,
            IFileRepository<StudioOneRootElement> saveRepository,
            ITextPresenter presenter )
        {
            SourceRepository = loadRepository;
            TargetRepository = saveRepository;
            Presenter        = presenter;
        }

        public void Convert( IFileConvertingRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var expressionMap = SourceRepository.Load();
            var expressionMapTranslator = new ExpressionMapTranslator();
            var keySwitchTranslator = new StudioOneKeySwitchTranslator();

            foreach( var keySwitch in expressionMapTranslator.Translate( expressionMap ) )
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