using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value
{
    [TestFixture]
    public class MidiProgramChangeMsbCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
            var obj2 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
            var obj2 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
            var obj4 = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiProgramChangeMsbCell.MinValue.ToString() );
        }
    }
}