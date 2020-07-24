using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {

        public void Convert( ConvertingFileFormatRequest request )
        {
            var loadRepository = new SpreadsheetRepository( request.InputFile );
            var saveRepository = new ExpressionMapXmlRepository();
            var workbook = loadRepository.Load();
            var workBookAdapter = new WorkbookAdapter();
            var expressionMapAdapter = new ExpressionMapAdapter();

            foreach( var expressionMap in workBookAdapter.Convert( workbook ) )
            {
                foreach( var xml in expressionMapAdapter.Convert( expressionMap ) )
                {

                    saveRepository.Path = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + "." + IExpressionMapXmlRepository.Suffix
                    );
                    saveRepository.Save( xml.RootElement );
                }
            }
        }
    }
}