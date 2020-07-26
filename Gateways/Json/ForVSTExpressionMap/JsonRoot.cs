using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class JsonRoot
    {
        [JsonProperty( "format_version", Required = Required.Always)]
        public string FormatVersion { get; set; }

        [JsonProperty( "info" )]
        public Info Info { get; set; } = new Info();

        [JsonProperty( "articulations" )]
        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}