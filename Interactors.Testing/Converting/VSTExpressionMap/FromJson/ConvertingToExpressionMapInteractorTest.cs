using ArticulationUtility.Gateways.Json.ForVSTExpressionMap;
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
            var loadRepository = new JsonRepository( @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/Template/Template_ExpressionMap.json" );
            var saveRepository = new ExpressionMapXmlRepository();
            var converter = new ConvertingToExpressionMapInteractor( loadRepository, saveRepository );
            var request = new ConvertingFileFormatRequest();

            request.OutputDirectory = @"/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp";
            converter.Convert( request );
        }
    }
}