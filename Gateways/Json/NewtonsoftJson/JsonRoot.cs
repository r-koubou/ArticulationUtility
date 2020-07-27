using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class JsonRoot
    {
        [JsonProperty( "format_version" )]
        public string FormatVersion { get; set; } = string.Empty;

        [JsonProperty( "info" )]
        public Info Info { get; set; } = new Info();

        [JsonProperty( "articulations" )]
        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}