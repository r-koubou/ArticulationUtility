using System;
using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap.FromJson;
using ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

using JsonRoot = ArticulationUtility.Entities.Json.Articulation.JsonRoot;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        private IFileRepository<JsonRoot> LoadRepository { get; }

        private IFileRepository<RootElement> SaveRepository { get; }

        public ConvertingToExpressionMapInteractor(
            IFileRepository<JsonRoot> loadRepository,
            IFileRepository<RootElement> saveRepository )
        {
            LoadRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            SaveRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            LoadRepository.LoadPath = request.InputFile;

            var json = LoadRepository.Load();
            var jsonAdapter = new JsonAdapter();
            var expressionMapAdapter = new ExpressionMapAdapter();

            foreach( var expressionMap in jsonAdapter.Convert( json ) )
            {
                foreach( var xml in expressionMapAdapter.Convert( expressionMap ) )
                {
                    SaveRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + SaveRepository.Suffix
                    );
                    SaveRepository.Save( xml );
                }
            }
        }
    }
}