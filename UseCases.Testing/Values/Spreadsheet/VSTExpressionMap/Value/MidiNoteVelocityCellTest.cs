using ArticulationUtility.UseCases.Values.Spreadsheet.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class MidiNoteVelocityCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
            var obj2 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiNoteVelocityCell( MidiNoteVelocityCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
            var obj2 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
            var obj4 = new MidiNoteVelocityCell( MidiNoteVelocityCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiNoteVelocityCell.MinValue.ToString() );
        }
    }
}