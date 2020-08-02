using System.IO;

using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.Json.FromVSTExpressionMapXml
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
            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new JsonFileRepository();
            var converter = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = Path.Combine( TestDataDir, @"Sample.expressionmap" ),
                OutputDirectory = TestOutputDir
            };
            converter.Convert( request );
        }
    }
}