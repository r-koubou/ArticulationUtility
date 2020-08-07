using System;
using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Json.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet
{
    public class ConvertingToJsonInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        private IFileRepository<Workbook> LoadRepository { get; }

        private IFileRepository<JsonRoot> SaveRepository { get; }

        public ConvertingToJsonInteractor(
            IFileRepository<Workbook> loadRepository,
            IFileRepository<JsonRoot> saveRepository )
        {
            LoadRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            SaveRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            LoadRepository.LoadPath = request.InputFile;

            var workbook = LoadRepository.Load();
            var toExpressionMapAdaptor = new WorkbookTranslator();
            var toJsonAdaptor = new ExpressionMapTranslator();

            var expressionMaps = toExpressionMapAdaptor.Translate( workbook );

            foreach( var expressionMap in expressionMaps )
            {
                var json = toJsonAdaptor.Translate( expressionMap );
                json.Info.Description = "Converted from spreadsheet";

                SaveRepository.SavePath = Path.Combine(
                    request.OutputDirectory,
                    json.Info.Name + SaveRepository.Suffix
                );
                SaveRepository.Save( json );
            }
        }
    }
}