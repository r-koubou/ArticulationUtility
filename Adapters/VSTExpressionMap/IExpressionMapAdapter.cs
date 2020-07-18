using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap;

namespace ArticulationUtility.Adapters.VSTExpressionMap
{
    public interface IExpressionMapAdapter
    {
        List<ExpressionMap> Convert();
    }
}