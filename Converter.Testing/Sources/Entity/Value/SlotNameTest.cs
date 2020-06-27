using System;

using Spreadsheet2Expressionmap.Converter.Entity.Value;
using NUnit.Framework;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entity.Value
{
    [TestFixture]
    public class SlotNameTest
    {
        [Test]
        public void NullOrEmptyNameTest()
        {
            Assert.Throws<ArgumentException>( () =>  new SlotName( "" ) );
            Assert.Throws<ArgumentException>( () =>  new SlotName( "  " ) );
            Assert.Throws<ArgumentException>( () =>  new SlotName( null ) );
            new SlotName( "Hoge" );
        }

        [Test]
        public void EqualityTest()
        {
            var hoge = new SlotName( "Hoge" );
            var huga = new SlotName( "Huga" );
            Assert.IsFalse( hoge.Equals( huga ) );

            var hoge1 = new SlotName( "Hoge" );
            var hoge2 = new SlotName( "Hoge" );
            Assert.IsTrue( hoge1.Equals( hoge2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new SlotName( "Hoge" ).ToString(), "Hoge" );
            Assert.IsTrue( new SlotName( "Hoge" ).ToString() == "Hoge" );
        }

    }
}