using ArticulationUtility.UseCases.Values.Spreadsheet.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class MidiChannelCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new MidiChannelCell( MidiChannelCell.MinValue );
            var obj2 = new MidiChannelCell( MidiChannelCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new MidiChannelCell( MidiChannelCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new MidiChannelCell( MidiChannelCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new MidiChannelCell( MidiChannelCell.MinValue );
            var obj2 = new MidiChannelCell( MidiChannelCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new MidiChannelCell( MidiChannelCell.MinValue );
            var obj4 = new MidiChannelCell( MidiChannelCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new MidiChannelCell( MidiChannelCell.MinValue );
            Assert.IsTrue( obj.ToString() == MidiChannelCell.MinValue.ToString() );
        }
    }
}