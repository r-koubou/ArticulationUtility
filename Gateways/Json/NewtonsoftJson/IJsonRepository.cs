using ArticulationUtility.Gateways.Common;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public interface IJsonRepository : IDataLoader<Entities.Json.Aggregate.JsonRoot>
    {
        public const string Suffix = "json";
        public string LoadPath { get; set; }
    }
}