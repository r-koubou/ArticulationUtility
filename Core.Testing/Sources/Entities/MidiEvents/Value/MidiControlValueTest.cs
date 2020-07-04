using NUnit.Framework;

using VSTExpressionMap.Core.Entities.MidiEvents.Value;

namespace VSTExpressionMap.Core.Testing.Entities.MidiEvents.Value
{
    [TestFixture]
    public class MidiControlValueTest
    {
        [Test]
        [TestCase( MidiControlValue.MinValue - 1 )]
        [TestCase( MidiControlValue.MaxValue + 1 )]
        public void OutOfRangeTest( int ccNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiControlValue( ccNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var cc1 = new MidiControlValue( 1 );
            var cc2 = new MidiControlValue( 2 );
            Assert.IsTrue( cc1.Equals( new MidiControlValue( 1 ) ) );
            Assert.IsFalse( cc1.Equals( cc2 ) );
            Assert.IsFalse( cc1.Equals( null ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiControlValue( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiControlValue( 1 ).ToString() == "1" );

        }

    }
}