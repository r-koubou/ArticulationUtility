using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiControlChangeValue : IMidiEventData, IEquatable<MidiControlChangeValue>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlChangeValue( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value  = value;
        }

        public bool Equals( MidiControlChangeValue other )
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