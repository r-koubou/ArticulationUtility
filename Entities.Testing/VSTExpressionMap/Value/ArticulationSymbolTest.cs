using ArticulationUtility.Entities.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.VSTExpressionMap.Value
{
    [TestFixture]
    public class ArticulationSymbolTest
    {
        [Test]
        [TestCase( ArticulationSymbol.MinValue - 1 )]
        [TestCase( ArticulationSymbol.MaxValue + 1 )]
        public void OutOfRangeTest( int groupValue )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new ArticulationSymbol( groupValue ) );
        }

        [Test]
        public void EqualityTest()
        {
            var idGenerator = new ArticulationIdGenerator();

            var obj1 = new ArticulationSymbol( ArticulationSymbol.MinValue );
            var obj2 = new ArticulationSymbol( ArticulationSymbol.MaxValue );
            var obj3 = idGenerator.Next();
            var obj4 = idGenerator.Next();
            Assert.AreEqual( obj1, new ArticulationSymbol( ArticulationSymbol.MinValue ) );
            Assert.AreNotEqual( obj1, obj2 );
            Assert.AreNotEqual( obj3, obj4 );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new ArticulationSymbol( 1 ).ToString(),"1" );
        }

    }
}