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
        [Test]
        public void ConvertTest()
        {
            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new JsonFileRepository();
            var converter = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest();
            request.InputFile       = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/2.expressionmap";
            request.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.Convert( request );
        }
    }
}