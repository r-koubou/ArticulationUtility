using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7
{
    [TestFixture]
    public class SpreadsheetConvertingInteractorTest
    {
        [Test]
        public void ConvertTest()
        {
            var converter = new ConvertingToExpressionMapInteractor();
            var request = new ConvertingFileFormatRequest();
            request.InputFile = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx";
            request.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.Convert( request );
        }
    }
}