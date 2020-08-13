using System;
using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Json.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate;
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
            var expressionMapAdapter = new ExpressionMapXmlTranslator();
            var jsonAdapter = new ExpressionMapTranslator();

            LoadRepository.LoadPath = request.InputFile;
            var xml = LoadRepository.Load();
            xml.StringElement.Value = Path.GetFileNameWithoutExtension( request.InputFile );

            var expressionMap = expressionMapAdapter.Translate( xml );

            var json = jsonAdapter.Translate( expressionMap );
            json.Info.Description = "Converted from expressionmap";
            SaveRepository.SavePath = Path.Combine(
                request.OutputDirectory,
                Path.GetFileNameWithoutExtension( request.InputFile ) + SaveRepository.Suffix
            );
            SaveRepository.Save( json );
        }
    }
}