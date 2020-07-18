using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.MidiEvents.Value
{
    public class MidiControlValue : IMidiEventData, IEquatable<MidiControlValue>
    {
        public static readonly int MinValue = 0x00;
        public static readonly int MaxValue = 0x7f;

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