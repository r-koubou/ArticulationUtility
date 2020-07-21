using ArticulationUtility.UseCases.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.VSTExpressionMap.Value;

using NUnit.Framework;

namespace UseCases.Testing.Data.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class ArticulationTest
    {
        [Test]
        public void SetupArticulationTest()
        {
            var articulation = new Articulation( new ArticulationName( "Name" ), ArticulationType.Direction, new ArticulationGroup( 1 ) );
        }
    }
}