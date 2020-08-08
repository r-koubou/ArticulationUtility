using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class ArticulationTest
    {
        [Test]
        public void SetupArticulationTest()
        {
            var idGenerator = new ArticulationIdGenerator();
            new Articulation( idGenerator.Next(),  new ArticulationName( "Name" ), ArticulationType.Direction, new ArticulationGroup( 1 ) );
        }
    }
}