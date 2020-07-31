using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class MidiMapping
    {
        [JsonProperty( "status" ) ]
        public string Status { get; set; } = string.Empty;

        [JsonProperty( "data1" )]
        public string Data1 { get; set; } = string.Empty;

        [JsonProperty( "data2" )]
        public string Data2 { get; set; } = string.Empty;
    }
}