using System;

using ArticulationUtility.Entities.MidiEvent.Value;

namespace ArticulationUtility.Entities.MidiEvent.Aggregate
{
    /// <summary>
    /// Represents a MIDI program change.
    /// </summary>
    public class MidiProgramChange : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public MidiProgramChange( MidiProgramChangeChannel channel, MidiProgramChangeNumber number )
        {
            DataByte1 = channel ?? throw new ArgumentNullException( $"{nameof( channel )}" );
            DataByte2 = number ?? throw new ArgumentNullException( $"{nameof( number )}" );
        }

    }
}