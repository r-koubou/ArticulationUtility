using ArticulationUtility.Gateways.Json.NewtonsoftJson;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.Json.ForVSTExpressionMap
{
    [TestFixture]
    public class JsonRepositoryTest
    {
        [Test]
        public void LoadTest()
        {
            var repository = new JsonFileRepository
            {
                LoadPath = "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/Template/Template_ExpressionMap.json"
            };
            var workbook = repository.Load();

            Assert.IsNotNull( workbook );
        }
    }
}