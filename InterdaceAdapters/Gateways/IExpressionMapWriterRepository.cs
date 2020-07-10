using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap;

namespace ArticulationUtility.Adapters.Gateways
{
    public interface IExpressionMapWriterRepository
    {
        public void Write( IReadOnlyList<ExpressionMap> expressionMaps );
    }
}