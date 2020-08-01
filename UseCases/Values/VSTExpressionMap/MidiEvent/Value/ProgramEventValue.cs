using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Value
{
    public class ProgramEventValue : IMidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public int Value { get; }

        public ProgramEventValue( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( ProgramEventValue other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}