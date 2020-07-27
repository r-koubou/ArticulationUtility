using System.Collections.Generic;

using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class Articulation
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "type" )]
        public string Type { get; set; }

        [JsonProperty( "color" )]
        public int Color { get; set; } = 0;

        [JsonProperty( "group" )]
        public int Group { get; set; } = 0;

        [JsonProperty( "midi_mapping" )]
        public List<MidiMapping> MidiMappings { get; set; } = new List<MidiMapping>();
    }
}