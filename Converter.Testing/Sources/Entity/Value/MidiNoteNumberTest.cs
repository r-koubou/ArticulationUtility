using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entity.Value
{
    [TestFixture]
    public class MidiNoteNumberTest
    {
        [TestCase( MidiNoteNumber.MinValue - 1 )]
        [TestCase( MidiNoteNumber.MaxValue + 1 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiNoteNumber( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var note1 = new MidiNoteNumber( 1 );
            var note2 = new MidiNoteNumber( 2 );
            Assert.IsTrue( note1.Equals( new MidiNoteNumber( 1 ) ) );
            Assert.IsFalse( note1.Equals( note2 ) );
            Assert.IsFalse( note1.Equals( null ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiNoteNumber( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiNoteNumber( 1 ).ToString() == "1" );
        }
    }
}