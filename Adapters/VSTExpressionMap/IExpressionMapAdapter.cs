using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;

namespace ArticulationUtility.Adapters.VSTExpressionMap
{
    public interface IExpressionMapAdapter<in TSource>
    {
        List<ExpressionMap> Convert( TSource source );
    }
}