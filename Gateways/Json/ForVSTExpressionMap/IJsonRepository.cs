using ArticulationUtility.Gateways.Common;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public interface IJsonRepository : IDataLoader<UseCases.Values.Json.ForVSTExpressionMap.JsonRoot>
    {
        public const string Suffix = "json";
        public string LoadPath { get; set; }
    }
}