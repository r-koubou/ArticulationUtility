using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.MidiEvents.Value
{
    [TestFixture]
    public class MidiMostSignificantByteTest
    {
        [TestCase( MidiMostSignificantByte.MinValue - 1 )]
        [TestCase( MidiMostSignificantByte.MaxValue + 1 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiMostSignificantByte( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var byte1 = new MidiMostSignificantByte( 1 );
            var byte2 = new MidiMostSignificantByte( 2 );
            Assert.IsTrue( byte1.Equals( new MidiMostSignificantByte( 1 ) ) );
            Assert.IsFalse( byte1.Equals( byte2 ) );

            // overridden operator ==, !=
            Assert.IsTrue( byte1 == new MidiMostSignificantByte( 1 ) );
            Assert.IsFalse( byte1 == byte2 );
            Assert.IsTrue( byte1 != byte2 );

            // overridden hashcode
            Assert.IsTrue( byte1.GetHashCode() == new MidiMostSignificantByte( 1 ).GetHashCode() );
            Assert.IsTrue( byte1.GetHashCode() != byte2.GetHashCode() );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiMostSignificantByte( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiMostSignificantByte( 1 ).ToString() == "1" );
        }
    }
}