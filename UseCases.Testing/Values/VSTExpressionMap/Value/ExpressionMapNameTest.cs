using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.VSTExpressionMap.Value
{
    [TestFixture]
    public class ExpressionMapNameTest
    {
        [Test]
        public void EmptyNameTest()
        {
            Assert.Throws<InvalidNameException>( () =>  new ExpressionMapName( "" ) );
            Assert.Throws<InvalidNameException>( () =>  new ExpressionMapName( "  " ) );
            new ExpressionMapName( "Hoge" );
        }

        [Test]
        public void EqualityTest()
        {
            var hoge = new ExpressionMapName( "Hoge" );
            var huga = new ExpressionMapName( "Huga" );
            Assert.IsFalse( hoge.Equals( huga ) );

            var hoge1 = new ExpressionMapName( "Hoge" );
            var hoge2 = new ExpressionMapName( "Hoge" );
            Assert.IsTrue( hoge1.Equals( hoge2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new ExpressionMapName( "Hoge" ).ToString(), "Hoge" );
            Assert.IsTrue( new ExpressionMapName( "Hoge" ).ToString() == "Hoge" );
        }

    }
}