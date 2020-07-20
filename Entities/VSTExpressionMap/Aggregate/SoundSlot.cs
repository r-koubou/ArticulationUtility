using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap.Aggregate
{
    /// <summary>
    /// Represents the sound slot in the expression map.
    /// </summary>
    public class SoundSlot
    {
        public SoundSlotName Name { get; }
        public SoundSlotColorIndex ColorIndex { get; set; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();

        public List<IMidiEvent> OutputMappings { get; } = new List<IMidiEvent>();

        public SoundSlot( SoundSlotName name, SoundSlotColorIndex colorIndex )
        {
            Name       = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            ColorIndex = colorIndex ?? new SoundSlotColorIndex( SoundSlotColorIndex.MinValue );
        }
    }
}