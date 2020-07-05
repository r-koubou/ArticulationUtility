using System.Collections.Generic;

using VSTExpressionMapTools.Domain.VSTExpressionMap;

namespace VSTExpressionMapTools.Adapters.Gateways
{
    public interface ISpreadsheetReaderRepository
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}