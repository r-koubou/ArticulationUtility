using System.IO;

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
        private static readonly string TestDataDir =
            Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                @"TestFiles/"
            );

        private static readonly string TestOutputDir = Path.Combine( TestDataDir, "out/" );

        [Test]
        public void ConvertTest()
        {
            var loadRepository = new SpreadsheetFileRepository();
            var saveRepository = new JsonFileRepository();
            var converter = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = Path.Combine( TestDataDir, @"Sample_Ver_0_8.xlsx" ),
                OutputDirectory = TestOutputDir
            };
            converter.Convert( request );
        }
    }
}