using System.Resources;

using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.VSTExpressionMap.Value
{
    [TestFixture]
    public class ArticulationIdTest
    {
        [Test]
        [TestCase( ArticulationId.MinValue - 1 )]
        [TestCase( ArticulationId.MaxValue + 1 )]
        public void OutOfRangeTest( int groupValue )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new ArticulationId( groupValue ) );
        }

        [Test]
        public void EqualityTest()
        {
            var idGenerator = new ArticulationIdGenerator();

            var obj1 = new ArticulationId( ArticulationId.MinValue );
            var obj2 = new ArticulationId( ArticulationId.MaxValue );
            var obj3 = idGenerator.Next();
            var obj4 = idGenerator.Next();
            Assert.AreEqual( obj1, new ArticulationId( ArticulationId.MinValue ) );
            Assert.AreNotEqual( obj1, obj2 );
            Assert.AreNotEqual( obj3, obj4 );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new ArticulationId( 1 ).ToString(),"1" );
        }

    }
}