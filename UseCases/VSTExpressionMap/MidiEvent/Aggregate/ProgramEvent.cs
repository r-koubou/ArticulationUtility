using System;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.VSTExpressionMap.MidiEvent.Value;

namespace ArticulationUtility.UseCases.VSTExpressionMap.MidiEvent.Aggregate
{
    public class ProgramEvent : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public ProgramEvent( ProgramEventValue value )
        {
            DataByte1 = value ?? throw new ArgumentNullException( $"{nameof( value )}" );
            DataByte2 = GenericMidiEventValue.Zero();
        }
    }
}