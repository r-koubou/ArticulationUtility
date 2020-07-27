using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value
{
    [TestFixture]
    public class ColorIndexCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new ColorIndexCell( ColorIndexCell.MinValue );
            var obj2 = new ColorIndexCell( ColorIndexCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new ColorIndexCell( ColorIndexCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new ColorIndexCell( ColorIndexCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new ColorIndexCell( ColorIndexCell.MinValue );
            var obj2 = new ColorIndexCell( ColorIndexCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new ColorIndexCell( ColorIndexCell.MinValue );
            var obj4 = new ColorIndexCell( ColorIndexCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new ColorIndexCell( ColorIndexCell.MinValue );
            Assert.IsTrue( obj.ToString() == ColorIndexCell.MinValue.ToString() );
        }
    }
}