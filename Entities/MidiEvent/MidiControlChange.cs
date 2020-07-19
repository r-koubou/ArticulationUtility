using System;

using ArticulationUtility.Entities.MidiEvent.Value;

namespace ArticulationUtility.Entities.MidiEvent
{
    /// <summary>
    /// Represents a MIDI control change.
    /// </summary>
    public class MidiControlChange : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public MidiControlChange( MidiControlChangeNumber controlChangeNumber, MidiControlChangeValue controlChangeValue )
        {
            DataByte1 = controlChangeNumber ?? throw new ArgumentNullException( $"{nameof( controlChangeNumber )}" );
            DataByte2 = controlChangeValue ?? throw new ArgumentNullException( $"{nameof( controlChangeValue )}" );
        }
    }
}