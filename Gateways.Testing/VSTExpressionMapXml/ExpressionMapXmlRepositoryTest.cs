using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.VSTExpressionMapXml
{
    [TestFixture]
    public class ExpressionMapXmlRepositoryTest
    {
        [Test]
        [TestCase( "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/DevTemplate.expressionmap" )]
        public void LoadTest( string path )
        {
            var repository = new ExpressionMapFileRepository
            {
                LoadPath = path
            };
            repository.Load();
        }

        [Test]
        [TestCase( "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/TestCase.out.expressionmap" )]
        public void SaveTest( string path )
        {
            var repository = new ExpressionMapFileRepository
            {
                SavePath = path
            };
            var root = new RootElement();
            repository.Save( root );
        }
    }
}