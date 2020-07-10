using System;

using ArticulationUtility.Domain.Helper;
using ArticulationUtility.Domain.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Domain.Testing.VSTExpressionMap.ExpressionMaps.Value
{
    [TestFixture]
    public class ExpressionMapNameTest
    {
        [Test]
        public void mptyNameTest()
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