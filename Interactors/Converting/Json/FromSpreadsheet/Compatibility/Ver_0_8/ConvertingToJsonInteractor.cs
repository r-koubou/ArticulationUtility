using System;
using System.IO;

using ArticulationUtility.Adapters.Json.FromVSTExpressionMap;
using ArticulationUtility.Adapters.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.Gateways;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.Articulation;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet.Compatibility.Ver_0_8
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
            var toExpressionMapAdaptor = new WorkbookAdapter();
            var toJsonAdaptor = new ExpressionMapAdapter();

            var expressionMaps = toExpressionMapAdaptor.Convert( workbook );

            foreach( var expressionMap in expressionMaps )
            {
                var json = toJsonAdaptor.Convert( expressionMap );
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