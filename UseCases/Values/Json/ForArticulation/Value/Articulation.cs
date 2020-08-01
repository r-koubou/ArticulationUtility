using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Json.ForArticulation.Value
{
    public class Articulation
    {
        public static class TypeAlias
        {
            public const string Direction = "Direction";
            public const string Attribute = "Attribute";
        }

        public static class MidiControlNameAlias
        {
            public const string MidiNoteOn = "NoteOn";
            public const string ControlChange = "ControlChange";
            public const string Program = "Program";
        }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Color { get; set; } = 0;

        public int Group { get; set; } = 0;

        public List<MidiMapping> MidiMappings { get; set; } = new List<MidiMapping>();
    }
}