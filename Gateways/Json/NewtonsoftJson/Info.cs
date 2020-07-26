using Newtonsoft.Json;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class Info
    {
        [JsonProperty( "version", Required = Required.Always )]
        public string Version { get; set; } = string.Empty;

        [JsonProperty( "name" )]
        public string Name { get; set; } = string.Empty;

        [JsonProperty( "author" )]
        public string Author { get; set; } = string.Empty;

        [JsonProperty( "product" )]
        public string Product { get; set; } = string.Empty;

        [JsonProperty( "url" )]
        public string Url { get; set; } = string.Empty;
    }
}