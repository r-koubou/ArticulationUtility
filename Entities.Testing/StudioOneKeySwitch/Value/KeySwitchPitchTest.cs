using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.StudioOneKeySwitch.Value
{
    [TestFixture]
    public class KeySwitchPitchTest
    {
        [TestCase( KeySwitchPitch.MinValue - 1 )]
        [TestCase( KeySwitchPitch.MaxValue + 1 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new KeySwitchPitch( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var note1 = new KeySwitchPitch( 1 );
            var note2 = new KeySwitchPitch( 2 );
            Assert.IsTrue( note1.Equals( new KeySwitchPitch( 1 ) ) );
            Assert.IsFalse( note1.Equals( note2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new KeySwitchPitch( 1 ).ToString(), "1" );
            Assert.IsTrue( new KeySwitchPitch( 1 ).ToString() == "1" );
        }
    }
}