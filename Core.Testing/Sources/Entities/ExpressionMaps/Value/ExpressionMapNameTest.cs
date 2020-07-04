using System;

using NUnit.Framework;

using VSTExpressionMap.Core.Entities.ExpressionMaps.Value;

namespace VSTExpressionMap.Core.Testing.Entities.ExpressionMaps.Value
{
    [TestFixture]
    public class ExpressionMapNameTest
    {
        [Test]
        public void NullOrEmptyNameTest()
        {
            Assert.Throws<ArgumentException>( () =>  new ExpressionMapName( "" ) );
            Assert.Throws<ArgumentException>( () =>  new ExpressionMapName( "  " ) );
            Assert.Throws<ArgumentException>( () =>  new ExpressionMapName( null ) );
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