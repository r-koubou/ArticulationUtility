using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.MidiEvents.Value
{
    [TestFixture]
    public class MidiVelocityTest
    {
        [TestCase( MidiVelocity.MinValue - 1 )]
        [TestCase( MidiVelocity.MaxValue + 1 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiVelocity( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var vel1 = new MidiVelocity( 10 );
            var vel2 = new MidiVelocity( 20 );
            Assert.IsTrue( vel1.Equals( new MidiVelocity( 10 ) ) );
            Assert.IsFalse( vel1.Equals( vel2 ) );

            // overridden operator ==, !=
            Assert.IsTrue( vel1 == new MidiVelocity( 10 ) );
            Assert.IsFalse( vel1 == vel2 );
            Assert.IsTrue( vel1 != vel2 );

            // overridden hashcode
            Assert.IsTrue( vel1.GetHashCode() == new MidiVelocity( 10 ).GetHashCode() );
            Assert.IsTrue( vel1.GetHashCode() != vel2.GetHashCode() );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiVelocity( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiVelocity( 1 ).ToString() == "1" );
        }
    }
}