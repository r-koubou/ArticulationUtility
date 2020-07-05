using System;

using NUnit.Framework;

using VSTExpressionMapTools.Domain.VSTExpressionMap.Value;

namespace VSTExpressionMap.Core.Testing.VSTExpressionMap.ExpressionMaps.Value
{
    [TestFixture]
    public class ArticulationNameTest
    {
        [Test]
        public void NullOrEmptyNameTest()
        {
            Assert.Throws<ArgumentException>( () =>  new ArticulationName( "" ) );
            Assert.Throws<ArgumentException>( () =>  new ArticulationName( "  " ) );
            Assert.Throws<ArgumentException>( () =>  new ArticulationName( null ) );
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