using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.MidiEvents.Value
{
    public class MidiControlValue : IMidiEventData, IEquatable<MidiControlValue>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlValue( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value  = value;
        }

        public bool Equals( MidiControlValue other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();

    }
}