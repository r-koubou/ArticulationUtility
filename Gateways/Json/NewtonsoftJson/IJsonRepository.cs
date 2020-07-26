using ArticulationUtility.Gateways.Common;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public interface IJsonRepository : IDataLoader<Entities.Json.Articulation.JsonRoot>
    {
        public const string Suffix = "json";
        public string LoadPath { get; set; }
    }
}