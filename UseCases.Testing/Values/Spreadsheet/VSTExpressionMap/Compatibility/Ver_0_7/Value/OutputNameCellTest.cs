using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value
{
    [TestFixture]
    public class OutputNameCellTest
    {
        [Test]
        public void ValueTest()
        {
            var obj = new OutputNameCell( "Hoge" );

            Assert.Throws<InvalidNameException>( () => { new OutputNameCell( "" ); } );
            Assert.Throws<InvalidNameException>( () => { new OutputNameCell( null ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var obj1 = new OutputNameCell( "Hoge" );
            var obj2 = new OutputNameCell( "Hoge" );
            Assert.AreEqual( obj1, obj2 );

            var obj3 = new OutputNameCell( "Hoge" );
            var obj4 = new OutputNameCell( "Huga" );
            Assert.AreNotEqual( obj3, obj4 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            var obj = new OutputNameCell( "Hoge" );
            Assert.IsTrue( obj.ToString() == "Hoge" );
        }
    }
}