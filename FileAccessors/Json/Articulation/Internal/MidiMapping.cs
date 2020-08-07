using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace ArticulationUtility.FileAccessors.Json.Articulation.Internal
{
    internal class MidiMapping
    {
        [JsonProperty( "status" ) ]
        public string Status { get; set; } = string.Empty;

        [JsonProperty( "data1" )]
        public string Data1 { get; set; } = string.Empty;

        [JsonProperty( "data2" )]
        public string Data2 { get; set; } = string.Empty;

        [SuppressMessage( "ReSharper", "UnusedMember.Global" )]
        public MidiMapping()
        {}
    }
}