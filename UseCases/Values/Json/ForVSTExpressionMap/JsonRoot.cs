using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap
{
    public class JsonRoot
    {
        public string FormatVersion { get; set; }
        public string Name { get; set; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();
    }
}