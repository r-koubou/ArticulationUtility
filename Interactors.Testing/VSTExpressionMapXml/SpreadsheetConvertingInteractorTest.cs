using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMapXml.Spreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.Spreadsheet;
using ArticulationUtility.Gateways.Spreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.VSTExpressionMapXml
{
    [TestFixture]
    public class SpreadsheetConvertingInteractorTest
    {
        [Test]
        public void ConvertTest()
        {
            var converter = new SpreadsheetConvertingInteractor();
            var repository = new SpreadsheetRepository( @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" );
            converter.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.LoadRepository = repository;
            converter.Convert();
        }
    }

    class SpreadsheetConvertingInteractor : ISpreadsheetConvertingUseCase
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