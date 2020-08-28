using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromJson;
using ArticulationUtility.Gateways.Translating.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson
{
    public class ConvertingToExpressionMapFileInteractor : IFileConvertingInteractor<JsonRoot, RootElement>
    {
        public IFileRepository<JsonRoot> SourceRepository { get; }

        public IFileRepository<RootElement> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        public ConvertingToExpressionMapFileInteractor(
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
            var jsonAdapter = new JsonTranslator();
            var expressionMapAdapter = new ExpressionMapTranslator();

            foreach( var expressionMap in jsonAdapter.Translate( json ) )
            {
                foreach( var xml in expressionMapAdapter.Translate( expressionMap ) )
                {
                    Presenter.Progress( expressionMap.Name.Value );

                    TargetRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + TargetRepository.Suffix
                    );
                    TargetRepository.Save( xml );
                }
            }
        }
    }
}