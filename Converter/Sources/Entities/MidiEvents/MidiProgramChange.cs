using System;

using VSTExpressionMap.Core.Entities.MidiEvents.Value;

namespace VSTExpressionMap.Core.Entities.MidiEvents
{
    /// <summary>
    /// Represents a MIDI program change.
    /// </summary>
    public class MidiProgramChange : IMidiEvent<MidiLeastSignificantByte, MidiMostSignificantByte>
    {
        public MidiLeastSignificantByte DataByte1 { get; }
        public MidiMostSignificantByte DataByte2 { get; }

        public MidiProgramChange( MidiLeastSignificantByte lsb, MidiMostSignificantByte msb )
        {
            DataByte1 = lsb ?? throw new ArgumentNullException( $"{nameof( lsb )}" );
            DataByte2 = msb ?? throw new ArgumentNullException( $"{nameof( msb )}" );
        }

    }
}