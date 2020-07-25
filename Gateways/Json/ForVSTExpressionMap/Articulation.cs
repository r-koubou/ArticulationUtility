using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    class Articulation
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "type" )]
        public string Type { get; set; }

        [JsonProperty( "color" )]
        public int Color { get; set; }

        [JsonProperty( "group" )]
        public int Group { get; set; }

        [JsonProperty( "output_mapping", Required = Required.DisallowNull)]
        public List<OutputMapping> OutputMapping { get; set; } = new List<OutputMapping>();
    }
}