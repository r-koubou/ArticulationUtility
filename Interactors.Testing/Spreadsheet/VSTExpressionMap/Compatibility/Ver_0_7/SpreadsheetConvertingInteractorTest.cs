using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7;
using ArticulationUtility.Interactors.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7
{
    [TestFixture]
    public class SpreadsheetConvertingInteractorTest
    {
        [Test]
        public void ConvertTest()
        {
            var converter = new ConvertingToExpressionMapInteractor();
            var repository = new SpreadsheetRepository( @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" );
            converter.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.LoadRepository = repository;
            converter.Convert();
        }
    }
}