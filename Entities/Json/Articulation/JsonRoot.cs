using System.Collections.Generic;

namespace ArticulationUtility.Entities.Json.Articulation
{
    public class JsonRoot
    {
        public string FormatVersion { get; set; }

        public Info Info { get; set; } = new Info();

        public List<Articulation> Articulations { get; set; } = new List<Articulation>();
    }
}