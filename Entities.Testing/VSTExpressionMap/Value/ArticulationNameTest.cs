using ArticulationUtility.Entities.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.VSTExpressionMap.Value
{
    [TestFixture]
    public class ArticulationNameTest
    {
        [Test]
        public void EmptyNameTest()
        {
            Assert.Throws<InvalidNameException>( () =>  new ArticulationName( "" ) );
            Assert.Throws<InvalidNameException>( () =>  new ArticulationName( "  " ) );
            new ArticulationName( "Hoge" );
        }

        [Test]
        public void EqualityTest()
        {
            var hoge = new ArticulationName( "Hoge" );
            var huga = new ArticulationName( "Huga" );
            Assert.IsFalse( hoge.Equals( huga ) );

            var hoge1 = new ArticulationName( "Hoge" );
            var hoge2 = new ArticulationName( "Hoge" );
            Assert.IsTrue( hoge1.Equals( hoge2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new ArticulationName( "Hoge" ).ToString(), "Hoge" );
            Assert.IsTrue( new ArticulationName( "Hoge" ).ToString() == "Hoge" );
        }

    }
}