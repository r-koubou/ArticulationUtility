using System;

using VSTExpressionMap.Core.Entities.MidiEvents.Value;

namespace VSTExpressionMap.Core.Entities.MidiEvents
{
    /// <summary>
    /// Representing a MIDI note on.
    /// </summary>
    public class MidiNoteOn : IMidiEvent<MidiNoteNumber, MidiVelocity>
    {
        public MidiNoteNumber DataByte1 { get; }
        public MidiVelocity DataByte2 { get; }

        public MidiNoteOn( MidiNoteNumber noteNumber, MidiVelocity velocity )
        {
            DataByte1 = noteNumber ?? throw new ArgumentNullException( $"{nameof( noteNumber )}" );
            DataByte2 = velocity ?? throw new ArgumentNullException( $"{nameof( velocity )}" );
        }

    }
}