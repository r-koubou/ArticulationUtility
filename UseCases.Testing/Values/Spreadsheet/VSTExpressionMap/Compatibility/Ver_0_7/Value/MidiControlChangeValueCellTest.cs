using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value
{
    [TestFixture]
    public class MidiControlChangeValueCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
            var obj2 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiControlChangeValueCell( MidiControlChangeValueCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
            var obj2 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
            var obj4 = new MidiControlChangeValueCell( MidiControlChangeValueCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiControlChangeValueCell.MinValue.ToString() );
        }
    }
}