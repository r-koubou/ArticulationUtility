using NUnit.Framework;

using VSTExpressionMapTools.Domain.MidiEvents.Value;

namespace VSTExpressionMap.Core.Testing.MidiEvents.Value
{
    [TestFixture]
    public class MidiControlNumberTest
    {
        [Test]
        [TestCase( MidiControlNumber.MinValue - 1 )]
        [TestCase( MidiControlNumber.MaxValue + 1 )]
        public void OutOfRangeTest( int ccNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiControlNumber( ccNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var cc1 = new MidiControlNumber( 1 );
            var cc2 = new MidiControlNumber( 2 );
            Assert.IsTrue( cc1.Equals( new MidiControlNumber( 1 ) ) );
            Assert.IsFalse( cc1.Equals( cc2 ) );
            Assert.IsFalse( cc1.Equals( null ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiControlNumber( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiControlNumber( 1 ).ToString() == "1" );
        }
    }
}