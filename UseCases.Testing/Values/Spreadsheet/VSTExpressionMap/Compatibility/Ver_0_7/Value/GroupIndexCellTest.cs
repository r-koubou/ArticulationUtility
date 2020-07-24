using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value
{
    [TestFixture]
    public class GroupIndexCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj1 = new GroupIndexCell( GroupIndexCell.MinValue );
            var obj2 = new GroupIndexCell( GroupIndexCell.MaxValue );

            Assert.Throws<ValueOutOfRangeException>( () => { new GroupIndexCell( GroupIndexCell.MinValue - 1 ); } );
            Assert.Throws<ValueOutOfRangeException>( () => { new GroupIndexCell( GroupIndexCell.MaxValue + 1 ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new GroupIndexCell( GroupIndexCell.MinValue );
            var obj2 = new GroupIndexCell( GroupIndexCell.MinValue );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new GroupIndexCell( GroupIndexCell.MinValue );
            var obj4 = new GroupIndexCell( GroupIndexCell.MaxValue );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new GroupIndexCell( GroupIndexCell.MinValue );
            Assert.IsTrue( obj.ToString() == GroupIndexCell.MinValue.ToString() );
        }
    }
}