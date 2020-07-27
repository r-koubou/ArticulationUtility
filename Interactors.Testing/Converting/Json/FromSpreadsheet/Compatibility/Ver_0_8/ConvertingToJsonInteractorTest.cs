using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8;
using ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.Json.FromSpreadsheet.Compatibility.Ver_0_8
{
    [TestFixture]
    public class ConvertingToJsonInteractorTest
    {
        [Test]
        public void ConvertTest()
        {
            var loadRepository = new SpreadsheetFileRepository();
            var saveRepository = new JsonFileRepository();
            var converter = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest();
            request.InputFile       = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template_0_8.xlsx";
            request.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.Convert( request );
        }
    }
}