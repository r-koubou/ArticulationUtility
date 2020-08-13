using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.MidiEvents.Value
{
    [TestFixture]
    public class MidiControlNumberTest
    {
        [Test]
        [TestCase( MidiControlChangeNumber.MinValue - 1 )]
        [TestCase( MidiControlChangeNumber.MaxValue + 1 )]
        public void OutOfRangeTest( int ccNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiControlChangeNumber( ccNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var cc1 = new MidiControlChangeNumber( 1 );
            var cc2 = new MidiControlChangeNumber( 2 );
            Assert.IsTrue( cc1.Equals( new MidiControlChangeNumber( 1 ) ) );
            Assert.IsFalse( cc1.Equals( cc2 ) );

            // overridden operator ==, !=
            Assert.IsTrue( cc1 == new MidiControlChangeNumber( 1 ) );
            Assert.IsFalse( cc1 == cc2 );
            Assert.IsTrue( cc1 != cc2 );

            // overridden hashcode
            Assert.IsTrue( cc1.GetHashCode() == new MidiControlChangeNumber( 1 ).GetHashCode() );
            Assert.IsTrue( cc1.GetHashCode() != cc2.GetHashCode() );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiControlChangeNumber( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiControlChangeNumber( 1 ).ToString() == "1" );
        }
    }
}