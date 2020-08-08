using System;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.VSTExpressionMap.MidiEvent.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap.MidiEvent.Aggregate
{
    public class ProgramEvent : IMidiEvent
    {
        public IMidiEventData Status { get; } = new MidiStatusCode( 0xC0 );
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public ProgramEvent( ProgramEventValue value )
        {
            DataByte1 = value ?? throw new ArgumentNullException( $"{nameof( value )}" );
            DataByte2 = GenericMidiEventValue.Zero();
        }
    }
}