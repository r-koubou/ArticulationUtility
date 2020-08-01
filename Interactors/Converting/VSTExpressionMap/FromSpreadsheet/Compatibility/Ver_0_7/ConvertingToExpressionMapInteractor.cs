using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {

        public void Convert( ConvertingFileFormatRequest request )
        {
            var loadRepository = new SpreadsheetFileRepository(){ LoadPath = request.InputFile };
            var saveRepository = new ExpressionMapFileRepository();
            var workbook = loadRepository.Load();
            var workBookAdapter = new WorkbookAdapter();
            var expressionMapAdapter = new ExpressionMapAdapter();

            foreach( var expressionMap in workBookAdapter.Convert( workbook ) )
            {
                foreach( var xml in expressionMapAdapter.Convert( expressionMap ) )
                {
                    saveRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + saveRepository.Suffix
                    );
                    saveRepository.Save( xml );
                }
            }
        }
    }
}