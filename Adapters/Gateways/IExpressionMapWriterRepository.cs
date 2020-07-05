using System.Collections.Generic;

using VSTExpressionMapTools.Domain.VSTExpressionMap;

namespace VSTExpressionMapTools.Adapters.Gateways
{
    public interface IExpressionMapWriterRepository
    {
        public void Write( IReadOnlyList<ExpressionMap> expressionMaps );
    }
}