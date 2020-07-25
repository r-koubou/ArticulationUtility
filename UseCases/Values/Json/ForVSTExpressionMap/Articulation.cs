using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap
{
    public class Articulation
    {
        public const string TypeDirection = "Direction";
        public const string TypeAttribute = "Attribute";

        public const string MidiNoteOn = "NoteOn";
        public const string ControlChange = "ControlChange";
        public const string Program = "Program";

        public string Name { get; set; }
        public string Type { get; set; }
        public int Color { get; set; }
        public int Group { get; set; }
        public List<OutputMapping> OutputMapping { get; } = new List<OutputMapping>();
    }
}