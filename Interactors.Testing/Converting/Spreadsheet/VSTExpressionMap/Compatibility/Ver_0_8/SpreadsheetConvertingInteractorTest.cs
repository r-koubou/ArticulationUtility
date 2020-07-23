using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8;
using ArticulationUtility.Interactors.Converting.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8
{
    [TestFixture]
    public class SpreadsheetConvertingInteractorTest
    {
        [Test]
        public void ConvertTest()
        {
            var converter = new ConvertingToExpressionMapInteractor();
            var repository = new SpreadsheetRepository( @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" );
            var request = new ConvertingFileFormatRequest();
            request.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.Convert( request );
        }
    }
}