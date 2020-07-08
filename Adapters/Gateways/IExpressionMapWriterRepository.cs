using System.Collections.Generic;

using ArticulationUtility.Domain.VSTExpressionMap;

namespace ArticulationUtility.Adapters.Gateways
{
    public interface IExpressionMapWriterRepository
    {
        public void Write( IReadOnlyList<ExpressionMap> expressionMaps );
    }
}