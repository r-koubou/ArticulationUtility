using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value
{
    [TestFixture]
    public class MidiProgramCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiProgramCell( MidiProgramCell.MinValue );
            var obj2 = new MidiProgramCell( MidiProgramCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramCell( MidiProgramCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiProgramCell( MidiProgramCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiProgramCell( MidiProgramCell.MinValue );
            var obj2 = new MidiProgramCell( MidiProgramCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiProgramCell( MidiProgramCell.MinValue );
            var obj4 = new MidiProgramCell( MidiProgramCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiProgramCell( MidiProgramCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiProgramCell.MinValue.ToString() );
        }
    }
}