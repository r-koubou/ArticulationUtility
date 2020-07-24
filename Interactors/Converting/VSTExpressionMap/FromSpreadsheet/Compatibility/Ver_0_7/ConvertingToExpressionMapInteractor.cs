using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMapXml.FromSpreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {

        public void Convert( ConvertingFileFormatRequest request )
        {
            var loadRepository = new SpreadsheetRepository( request.InputFile );
            var saveRepository = new ExpressionMapXmlRepository();
            var workbook = loadRepository.Load();
            var adapter = new WorkbookAdapter();

            foreach( var xml in adapter.Convert( workbook ) )
            {
                saveRepository.Path = Path.Combine(
                    request.OutputDirectory,
                    xml.FileName + "." + IExpressionMapXmlRepository.Suffix
                );

                saveRepository.Save( xml.RootElement );
            }
        }
    }
}