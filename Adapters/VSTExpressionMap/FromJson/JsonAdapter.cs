using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;

namespace ArticulationUtility.Adapters.VSTExpressionMap.FromJson
{
    public class JsonAdapter : IExpressionMapAdapter<JsonRoot>
    {
        public List<ExpressionMap> Convert( JsonRoot source )
        {
            throw new System.NotImplementedException();
        }
    }
}