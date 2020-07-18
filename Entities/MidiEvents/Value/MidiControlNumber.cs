using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.MidiEvents.Value
{
    public class MidiControlNumber : IMidiEventData, IEquatable<MidiControlNumber>
    {
        public static readonly int MinValue = 0x00;
        public static readonly int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlNumber( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( MidiControlNumber other )
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