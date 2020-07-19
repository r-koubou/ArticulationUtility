using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvents.Value
{
    public class MidiLeastSignificantByte : IMidiEventData, IEquatable<MidiLeastSignificantByte>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiLeastSignificantByte( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( MidiLeastSignificantByte other )
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