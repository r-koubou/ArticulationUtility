using System.IO;

using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.VSTExpressionMapXml
{
    [TestFixture]
    public class ExpressionMapXmlRepositoryTest
    {
        private static readonly string TestDataDir =
            Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                @"TestFiles/"
            );

        private static readonly string TestOutputDir = Path.Combine( TestDataDir, "out/" );

        [Test]
        public void LoadTest()
        {
            var repository = new ExpressionMapFileRepository
            {
                LoadPath = Path.Combine( TestDataDir, @"Sample.expressionmap" )
            };
            repository.Load();
        }

        [Test]
        public void SaveTest()
        {
            var repository = new ExpressionMapFileRepository
            {
                SavePath = Path.Combine( TestOutputDir, @"SaveTest.expressionmap" )
            };
            var root = new RootElement();
            repository.Save( root );
        }
    }
}