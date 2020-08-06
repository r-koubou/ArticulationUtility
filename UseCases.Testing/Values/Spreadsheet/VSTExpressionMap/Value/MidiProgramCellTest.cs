using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class MidiProgramCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiProgramChangeCell( MidiProgramChangeCell.MinValue );
            var obj2 = new MidiProgramChangeCell( MidiProgramChangeCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeCell( MidiProgramChangeCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeCell( MidiProgramChangeCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiProgramChangeCell( MidiProgramChangeCell.MinValue );
            var obj2 = new MidiProgramChangeCell( MidiProgramChangeCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiProgramChangeCell( MidiProgramChangeCell.MinValue );
            var obj4 = new MidiProgramChangeCell( MidiProgramChangeCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiProgramChangeCell( MidiProgramChangeCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiProgramChangeCell.MinValue.ToString() );
        }
    }
}