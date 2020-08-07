using System;

using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class MidiNoteNumberCellText
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiNoteNumberCell( "C-2 (0)" );
            var obj2 = new MidiNoteNumberCell( "G8 (127)" );

            Assert.Throws<ArgumentException>( () => { new MidiNoteNumberCell( "" ); } );
            Assert.Throws<ArgumentException>( () => { new MidiNoteNumberCell( "Invalid" ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiNoteNumberCell( "C-2 (0)" );
            var obj2 = new MidiNoteNumberCell( "C-2 (0)" );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiNoteNumberCell( "C-2 (0)" );
            var obj4 = new MidiNoteNumberCell( "C#-2 (1)" );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiNoteNumberCell( "C-2 (0)" );
            Assert.IsTrue( obj.ToString() == "C-2 (0)" );
        }

    }
}