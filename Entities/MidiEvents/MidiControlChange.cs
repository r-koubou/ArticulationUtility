using System;

using ArticulationUtility.Entities.MidiEvents.Value;

namespace ArticulationUtility.Entities.MidiEvents
{
    /// <summary>
    /// Represents a MIDI control change.
    /// </summary>
    public class MidiControlChange : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public MidiControlChange( MidiControlNumber controlNumber, MidiControlValue controlValue )
        {
            DataByte1 = controlNumber ?? throw new ArgumentNullException( $"{nameof( controlNumber )}" );
            DataByte2 = controlValue ?? throw new ArgumentNullException( $"{nameof( controlValue )}" );
        }
    }
}