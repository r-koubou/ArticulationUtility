using System;
using System.IO;

using ArticulationUtility.Adapters.Json.FromVSTExpressionMap;
using ArticulationUtility.Adapters.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class ConvertingToJsonInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        private ISpreadsheetRepository<Workbook> LoadRepository { get; }

        private IJsonRepository SaveRepository { get; }

        public ConvertingToJsonInteractor(
            ISpreadsheetRepository<Workbook> loadRepository,
            IJsonRepository saveRepository )
        {
            LoadRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            SaveRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            var workbook = LoadRepository.Load();
            var toExpressionMapAdaptor = new WorkbookAdapter();
            var toJsonAdaptor = new ExpressionMapAdapter();

            var expressionMaps = toExpressionMapAdaptor.Convert( workbook );

            foreach( var expressionMap in expressionMaps )
            {
                var json = toJsonAdaptor.Convert( expressionMap );

                SaveRepository.SavePath = Path.Combine(
                    request.OutputDirectory,
                    json.Info.Name + IJsonRepository.Suffix
                );
                SaveRepository.Save( json );
            }
        }
    }
}