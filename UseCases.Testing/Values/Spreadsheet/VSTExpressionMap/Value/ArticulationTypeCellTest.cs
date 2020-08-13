using System;

using ArticulationUtility.UseCases.Values.Spreadsheet.Value;

using NUnit.Framework;

namespace UseCases.Testing.Values.Spreadsheet.VSTExpressionMap.Value
{
    [TestFixture]
    public class ArticulationTypeCellTest
    {
        [Test]
        public void ValueTest()
        {
            ArticulationTypeCell.Parse( "Direction" );
            ArticulationTypeCell.Parse( "Attribute" );
            ArticulationTypeCell.Parse( ArticulationTypeCell.Direction.Value );
            ArticulationTypeCell.Parse( ArticulationTypeCell.Attribute.Value );

            Assert.Throws<ArgumentException>( () => { ArticulationTypeCell.Parse( "Invalid Value" ); } );
            Assert.Throws<ArgumentException>( () => { ArticulationTypeCell.Parse( "" ); } );
        }

        [Test]
        public void EqualityTest()
        {
            var direct1 = ArticulationTypeCell.Parse( ArticulationTypeCell.Direction.Value );
            var direct2 = ArticulationTypeCell.Parse( ArticulationTypeCell.Direction.Value );
            Assert.AreEqual( direct1, direct2 );

            direct1 = ArticulationTypeCell.Direction;
            direct2 = ArticulationTypeCell.Direction;
            Assert.AreEqual( direct1, direct2 );

            direct1 = ArticulationTypeCell.Direction;
            direct2 = ArticulationTypeCell.Attribute;
            Assert.AreNotEqual( direct1, direct2 );

            var attr1 = ArticulationTypeCell.Parse( ArticulationTypeCell.Attribute.Value );
            var attr2 = ArticulationTypeCell.Parse( ArticulationTypeCell.Attribute.Value );
            Assert.AreEqual( attr1, attr2 );

            attr1 = ArticulationTypeCell.Attribute;
            attr2 = ArticulationTypeCell.Attribute;
            Assert.AreEqual( attr1, attr2 );

            attr1 = ArticulationTypeCell.Direction;
            attr2 = ArticulationTypeCell.Attribute;
            Assert.AreNotEqual( attr1, attr2 );

        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.IsTrue( ArticulationTypeCell.Direction.ToString() == "Direction" );
            Assert.IsTrue( ArticulationTypeCell.Attribute.ToString() == "Attribute" );
        }
    }
}