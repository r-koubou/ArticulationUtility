using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    internal class Articulation
    {
        [JsonProperty( "name" )]
        public string Name { get; set; } = string.Empty;

        [JsonProperty( "type" )]
        public string Type { get; set; } = string.Empty;

        [JsonProperty( "color" )]
        public int Color { get; set; }

        [JsonProperty( "group" )]
        public int Group { get; set; }

        [JsonProperty( "midi_mapping" )]
        public List<MidiMapping> MidiMappings { get; set; } = new List<MidiMapping>();
    }
}