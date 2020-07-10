using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap
{
    /// <summary>
    /// Represents the sound slot in the expression map.
    /// </summary>
    public class SoundSlot
    {
        public SoundSlotName Name { get; }
        public SoundSlotColorIndex ColorIndex { get; set; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();

        public List<OutputMapping> OutputMappings { get; } = new List<OutputMapping>();

        public SoundSlot( SoundSlotName name, SoundSlotColorIndex colorIndex )
        {
            Name       = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            ColorIndex = colorIndex ?? new SoundSlotColorIndex( SoundSlotColorIndex.MinValue );
        }
    }
}