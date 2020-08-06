using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace ArticulationUtility.FileAccessing.Json.Articulation.Internal
{
    internal class JsonRoot
    {
        [JsonProperty( "format_version" )]
        public string FormatVersion { get; set; } = string.Empty;

        [JsonProperty( "info" )]
        public Info Info { get; set; } = new Info();

        [JsonProperty( "articulations" )]
        public List<Articulation> Articulations { get; set; } = new List<Articulation>();

        [SuppressMessage( "ReSharper", "UnusedMember.Global" )]
        public JsonRoot()
        {}
    }
}