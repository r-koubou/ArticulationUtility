using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.Json.ForArticulation.Value;

namespace ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate
{
    public class JsonRoot
    {
        public const string ThisFormatVersion = "0.0.1";

        public string FormatVersion { get; set; } = ThisFormatVersion;

        public Info Info { get; set; } = new Info();

        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}