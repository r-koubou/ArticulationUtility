using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvents.Value
{
    public class MidiMostSignificantByte : IMidiEventData, IEquatable<MidiMostSignificantByte>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiMostSignificantByte( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( MidiMostSignificantByte other )
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