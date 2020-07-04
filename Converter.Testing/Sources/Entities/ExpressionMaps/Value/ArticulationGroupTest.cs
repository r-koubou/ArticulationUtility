using NUnit.Framework;

using VSTExpressionMap.Core.Entities.ExpressionMaps.Value;
using VSTExpressionMap.Core.Entities.MidiEvents.Value;

namespace VSTExpressionMap.Core.Testing.Entities.ExpressionMaps.Value
{
    [TestFixture]
    public class ArticulationGroupTest
    {
        [Test]
        [TestCase( ArticulationGroup.MinValue - 1 )]
        [TestCase( ArticulationGroup.MaxValue + 1 )]
        public void OutOfRangeTest( int groupValue )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new ArticulationGroup( groupValue ) );
        }

        [Test]
        public void EqualityTest()
        {
            var group1 = new ArticulationGroup( 1 );
            var group2 = new ArticulationGroup( 2 );
            Assert.IsTrue( group1.Equals( new ArticulationGroup( 1 ) ) );
            Assert.IsFalse( group1.Equals( group2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new ArticulationGroup( 1 ).ToString(),"1" );
            Assert.IsTrue( new ArticulationGroup( 1 ).ToString() == "1" );
        }

    }
}