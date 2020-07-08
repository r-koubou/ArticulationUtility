using System;

using ArticulationUtility.Domain.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Domain.Testing.VSTExpressionMap.ExpressionMaps.Value
{
    [TestFixture]
    public class SlotNameTest
    {
        [Test]
        public void NullOrEmptyNameTest()
        {
            Assert.Throws<ArgumentException>( () =>  new SoundSlotName( "" ) );
            Assert.Throws<ArgumentException>( () =>  new SoundSlotName( "  " ) );
            Assert.Throws<ArgumentException>( () =>  new SoundSlotName( null ) );
            new SoundSlotName( "Hoge" );
        }

        [Test]
        public void EqualityTest()
        {
            var hoge = new SoundSlotName( "Hoge" );
            var huga = new SoundSlotName( "Huga" );
            Assert.IsFalse( hoge.Equals( huga ) );

            var hoge1 = new SoundSlotName( "Hoge" );
            var hoge2 = new SoundSlotName( "Hoge" );
            Assert.IsTrue( hoge1.Equals( hoge2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new SoundSlotName( "Hoge" ).ToString(), "Hoge" );
            Assert.IsTrue( new SoundSlotName( "Hoge" ).ToString() == "Hoge" );
        }

    }
}