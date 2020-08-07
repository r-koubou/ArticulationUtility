using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromJson;
using ArticulationUtility.Gateways.Translating.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson
{
    public class ConvertingToExpressionMapFileInteractor : IFileConvertingInteractor<JsonRoot, RootElement>
    {
        public IFileRepository<JsonRoot> SourceRepository { get; }

        public IFileRepository<RootElement> TargetRepository { get; }

        public ConvertingToExpressionMapFileInteractor(
            IFileRepository<JsonRoot> loadRepository,
            IFileRepository<RootElement> saveRepository )
        {
            SourceRepository = loadRepository;
            TargetRepository = saveRepository;
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var json = SourceRepository.Load();
            var jsonAdapter = new JsonTranslator();
            var expressionMapAdapter = new ExpressionMapTranslator();

            foreach( var expressionMap in jsonAdapter.Translate( json ) )
            {
                foreach( var xml in expressionMapAdapter.Translate( expressionMap ) )
                {
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