using System.Collections.Generic;

using VSTExpressionMap.Core.Entities.ExpressionMaps;

namespace VSTExpressionMap.Core.Presenters
{
    public interface IExpressionMapWriter
    {
        public void Write( IReadOnlyList<ExpressionMap> expressionMaps );
    }
}