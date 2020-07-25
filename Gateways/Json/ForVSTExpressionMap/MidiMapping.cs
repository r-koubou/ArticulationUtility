using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class MidiMapping
    {
        [JsonProperty( "status" )]
        public string Status { get; set; }

        [JsonProperty( "data1" )]
        public string Data1 { get; set; }

        [JsonProperty( "data2" )]
        public string Data2 { get; set; }
    }
}