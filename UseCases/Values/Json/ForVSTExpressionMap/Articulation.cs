using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap
{
    public class Articulation
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Color { get; set; }
        public int Group { get; set; }
        public List<OutputMapping> OutputMapping { get; } = new List<OutputMapping>();
    }
}