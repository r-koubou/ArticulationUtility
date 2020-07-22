using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMapXml.Spreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases;

namespace ArticulationUtility.Interactors.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase
    {
        public string OutputDirectory { get; set; } = ".";
        public ISpreadsheetRepository LoadRepository { get; set; }

        public void Convert()
        {
            var workbook = LoadRepository.Load();
            var adapter = new WorkbookAdapter();
            var saveRepository = new ExpressionMapXmlRepository();

            foreach( var xml in adapter.Convert( workbook ) )
            {
                saveRepository.Path = Path.Combine(
                    OutputDirectory,
                    xml.FileName + "." + IExpressionMapXmlRepository.Suffix
                );

                saveRepository.Save( xml.RootElement );
            }
        }
    }
}