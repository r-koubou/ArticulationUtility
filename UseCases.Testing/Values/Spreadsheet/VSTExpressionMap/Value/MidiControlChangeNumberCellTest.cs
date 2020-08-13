using ArticulationUtility.UseCases.Values.Spreadsheet.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class MidiControlChangeNumberCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            var obj2 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            var obj2 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            var obj4 = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiControlChangeNumberCell.MinValue.ToString() );
        }
    }
}