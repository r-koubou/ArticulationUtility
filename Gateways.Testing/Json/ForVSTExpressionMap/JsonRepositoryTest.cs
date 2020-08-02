using System.IO;

using ArticulationUtility.Gateways.Json.NewtonsoftJson;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.Json.ForVSTExpressionMap
{
    [TestFixture]
    public class JsonRepositoryTest
    {
        private static readonly string TestDataDir =
            Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                @"Json/ForVSTExpressionMap/TestFiles/"
            );

        [Test]
        public void LoadTest()
        {
            var repository = new JsonFileRepository
            {
                LoadPath = Path.Combine( TestDataDir, @"JsonRepositoryTest.json" )
            };
            var workbook = repository.Load();

            Assert.IsNotNull( workbook );
        }
    }
}