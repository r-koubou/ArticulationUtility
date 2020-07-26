using ArticulationUtility.Gateways.Common;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public interface IJsonRepository :
        IFileLoader<Entities.Json.Articulation.JsonRoot>,
        IFileSaver<Entities.Json.Articulation.JsonRoot>
    {
        public const string Suffix = ".json";
    }
}