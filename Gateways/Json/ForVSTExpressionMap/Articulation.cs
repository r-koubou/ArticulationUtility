using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class Articulation
    {
        [JsonProperty( "name", Required = Required.Always )]
        public string Name { get; set; }

        [JsonProperty( "type" )]
        public string Type { get; set; }

        [JsonProperty( "color" )]
        public int Color { get; set; }

        [JsonProperty( "group" )]
        public int Group { get; set; }

        [JsonProperty( "midi_mapping" )]
        public List<MidiMapping> MidiMapping { get; set; } = new List<MidiMapping>();
    }
}