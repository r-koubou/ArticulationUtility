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
        public SoundSlotColorIndex ColorIndex { get; }
        public IReadOnlyList<ArticulationId> ReferenceArticulationIds { get; }

        public IReadOnlyList<IMidiEvent> OutputMappings { get; }

        public SoundSlot(
            SoundSlotName name,
            SoundSlotColorIndex colorIndex,
            IEnumerable<ArticulationId> referenceArticulationIds,
            IEnumerable<IMidiEvent> outputMappings )
        {
            Name                     = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            ColorIndex               = colorIndex ?? new SoundSlotColorIndex( SoundSlotColorIndex.MinValue );
            ReferenceArticulationIds = new List<ArticulationId>( referenceArticulationIds );
            OutputMappings           = new List<IMidiEvent>( outputMappings );
        }
    }
}