using System;

using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps;
using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps.Value;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entities.ExpressionMaps
{
    [TestFixture]
    public class ArticulationTest
    {
        [Test]
        public void SetupArticulationTest()
        {
            var articulation = new Articulation( new ArticulationName( "Name" ), ArticulationType.Direction, new ArticulationGroup( 1 ) );
        }

        [Test]
        public void NullTest()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Articulation(
                    null,
                    ArticulationType.Direction,
                    new ArticulationGroup( 1 )
                )
            );
            Assert.Throws<ArgumentNullException>(
                () => new Articulation(
                    new ArticulationName( "Name" ),
                    ArticulationType.Direction,
                    null
                )
            );
            Assert.Throws<ArgumentNullException>(
                () => new Articulation(
                    null,
                    ArticulationType.Direction,
                    null
                )
            );
        }
    }
}