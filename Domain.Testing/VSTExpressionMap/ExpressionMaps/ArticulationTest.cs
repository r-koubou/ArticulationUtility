using System;

using ArticulationUtility.Domain.VSTExpressionMap;
using ArticulationUtility.Domain.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Domain.Testing.VSTExpressionMap.ExpressionMaps
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