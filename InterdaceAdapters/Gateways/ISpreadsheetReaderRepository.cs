using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap;

namespace ArticulationUtility.Adapters.Gateways
{
    public interface ISpreadsheetReaderRepository
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}