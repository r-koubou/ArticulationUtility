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
        [Test]
        public void ConvertTest()
        {
            var loadRepository = new JsonFileRepository();
            var saveRepository = new ExpressionMapFileRepository();
            var converter = new ConvertingToExpressionMapInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/Template/Template_ExpressionMap.json",
                OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp"
            };
            converter.Convert( request );
        }
    }
}