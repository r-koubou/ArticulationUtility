using System;

using ArticulationUtility.Domain.MidiEvents.Value;

namespace ArticulationUtility.Domain.MidiEvents
{
    /// <summary>
    /// Represents a MIDI program change.
    /// </summary>
    public class MidiProgramChange : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public MidiProgramChange( MidiLeastSignificantByte lsb, MidiMostSignificantByte msb )
        {
            DataByte1 = lsb ?? throw new ArgumentNullException( $"{nameof( lsb )}" );
            DataByte2 = msb ?? throw new ArgumentNullException( $"{nameof( msb )}" );
        }

    }
}