using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class JsonRoot
    {
        [JsonProperty( "info" )]
        public Info Info { get; set; } = new Info();

        [JsonProperty( "articulations" )]
        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}