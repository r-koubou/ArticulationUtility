using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;

namespace ArticulationUtility.Adapters.VSTExpressionMap
{
    public interface IExpressionMapAdapter<in TSource>
    {
        List<ExpressionMap> Convert( TSource source );
    }
}