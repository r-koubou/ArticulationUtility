using NUnit.Framework;

using VSTExpressionMapTools.Domain.MidiEvents.Value;
using VSTExpressionMapTools.Domain.VSTExpressionMap.Value;

namespace VSTExpressionMap.Core.Testing.VSTExpressionMap.ExpressionMaps.Value
{
    [TestFixture]
    public class SoundSlotColorIndexTest
    {
        [Test]
        [TestCase( SoundSlotColorIndex.MinValue - 1 )]
        [TestCase( SoundSlotColorIndex.MaxValue + 1 )]
        public void OutOfRangeTest( int index )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new SoundSlotColorIndex( index ) );
        }

        [Test]
        public void EqualityTest()
        {
            var index1 = new SoundSlotColorIndex( 1 );
            var index2 = new SoundSlotColorIndex( 2 );
            Assert.IsTrue( index1.Equals( new SoundSlotColorIndex( 1 ) ) );
            Assert.IsFalse( index1.Equals( index2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new SoundSlotColorIndex( 1 ).ToString(),"1" );
            Assert.IsTrue( new SoundSlotColorIndex( 1 ).ToString() == "1" );
        }

    }
}