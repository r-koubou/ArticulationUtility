using System.Collections.Generic;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps;

namespace Spreadsheet2Expressionmap.Converter.Gateways
{
    public interface IExpressionMapWriter
    {
        public void Write( IReadOnlyList<ExpressionMap> expressionMaps );
    }
}