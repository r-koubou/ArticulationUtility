using System.IO;

using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.VSTExpressionMap.FromJson
{
    [TestFixture]
    public class ConvertingToExpressionMapInteractorTest
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
            var loadRepository = new JsonFileRepository();
            var saveRepository = new ExpressionMapFileRepository();
            var converter = new ConvertingToExpressionMapInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest
            {
                InputFile = Path.Combine( TestDataDir, @"ExpressionMapSample.json" ),
                OutputDirectory = TestOutputDir
            };
            converter.Convert( request );
        }
    }
}