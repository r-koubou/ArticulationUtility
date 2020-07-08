using System.Collections.Generic;

using ArticulationUtility.Domain.VSTExpressionMap;

namespace ArticulationUtility.Adapters.Gateways
{
    public interface ISpreadsheetReaderRepository
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}