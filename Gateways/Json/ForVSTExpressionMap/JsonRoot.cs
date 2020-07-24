using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    class JsonRoot
    {
        [JsonProperty( "format_version" )]
        public string FormatVersion { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "articulations" )]
        public List<Articulation> Articulations { get; set; }
    }
}