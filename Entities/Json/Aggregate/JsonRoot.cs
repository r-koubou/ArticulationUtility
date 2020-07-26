using System.Collections.Generic;

using ArticulationUtility.Entities.Json.Value;

namespace ArticulationUtility.Entities.Json.Aggregate
{
    public class JsonRoot
    {
        public string FormatVersion { get; set; }

        public Info Info { get; set; } = new Info();

        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}