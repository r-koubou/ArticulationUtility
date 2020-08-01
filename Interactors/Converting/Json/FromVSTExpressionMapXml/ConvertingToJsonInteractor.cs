using System;
using System.IO;

using ArticulationUtility.Adapters.Json.FromVSTExpressionMap;
using ArticulationUtility.Adapters.VSTExpressionMap.FromVSTExpressionMapXml;
using ArticulationUtility.Gateways;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.Articulation;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml
{
    public class ConvertingToJsonInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        private IFileRepository<RootElement> LoadRepository { get; }
        private IFileRepository<JsonRoot> SaveRepository { get; }
        public ConvertingToJsonInteractor(
            IFileRepository<RootElement> loadRepository,
            IFileRepository<JsonRoot> saveRepository )
        {
            LoadRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            SaveRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            var expressionMapAdapter = new VSTExpressionMapXmlAdapter();
            var jsonAdapter = new ExpressionMapAdapter();

            LoadRepository.LoadPath = request.InputFile;
            var xml = LoadRepository.Load();
            xml.Name = Path.GetFileNameWithoutExtension( request.InputFile );

            var expressionMap = expressionMapAdapter.Convert( xml );

            var json = jsonAdapter.Convert( expressionMap );
            json.Info.Description = "Converted from expressionmap";
            SaveRepository.SavePath = Path.Combine(
                request.OutputDirectory,
                Path.GetFileNameWithoutExtension( request.InputFile ) + SaveRepository.Suffix
            );
            SaveRepository.Save( json );
        }
    }
}