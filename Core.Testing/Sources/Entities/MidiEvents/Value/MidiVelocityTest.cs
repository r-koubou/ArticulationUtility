using NUnit.Framework;

using VSTExpressionMap.Core.Entities.MidiEvents.Value;

namespace VSTExpressionMap.Core.Testing.Entities.MidiEvents.Value
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
            Assert.IsFalse( vel1.Equals( null ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiVelocity( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiVelocity( 1 ).ToString() == "1" );
        }
    }
}