using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.StudioOneKeySwitch.Value
{
    [TestFixture]
    public class KeySwitchNameTest
    {
        [Test]
        public void EmptyNameTest()
        {
            Assert.Throws<InvalidNameException>( () =>  new KeySwitchName( "" ) );
            Assert.Throws<InvalidNameException>( () =>  new KeySwitchName( "  " ) );
            new KeySwitchName( "Hoge" );
        }

        [Test]
        public void EqualityTest()
        {
            var hoge = new KeySwitchName( "Hoge" );
            var huga = new KeySwitchName( "Huga" );
            Assert.IsFalse( hoge.Equals( huga ) );

            var hoge1 = new KeySwitchName( "Hoge" );
            var hoge2 = new KeySwitchName( "Hoge" );
            Assert.IsTrue( hoge1.Equals( hoge2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new KeySwitchName( "Hoge" ).ToString(), "Hoge" );
            Assert.IsTrue( new KeySwitchName( "Hoge" ).ToString() == "Hoge" );
        }

    }
}