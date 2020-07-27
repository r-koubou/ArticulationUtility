using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value
{
    [TestFixture]
    public class MidiProgramChangeLsbCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            var obj2 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            var obj2 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            var obj4 = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiProgramChangeLsbCell.MinValue.ToString() );
        }
    }
}