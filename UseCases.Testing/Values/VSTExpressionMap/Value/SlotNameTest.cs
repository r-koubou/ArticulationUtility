using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.VSTExpressionMap.Value
{
    [TestFixture]
    public class SlotNameTest
    {
        [Test]
        public void EmptyNameTest()
        {
            Assert.Throws<InvalidNameException>( () =>  new SoundSlotName( "" ) );
            Assert.Throws<InvalidNameException>( () =>  new SoundSlotName( "  " ) );
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