using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Data.VSTExpressionMapXml;

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
            var repository = new ExpressionMapXmlRepository(){ Path = path };
            var expressionMap = repository.Load();
        }

        [Test]
        [TestCase( "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/TestCase.out.expressionmap" )]
        public void SaveTest( string path )
        {
            var repository = new ExpressionMapXmlRepository(){ Path = path };
            var root = new InstrumentMapElement();
            repository.Save( root );
        }
    }
}