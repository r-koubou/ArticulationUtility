using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiControlChangeNumber : IMidiEventData, IEquatable<MidiControlChangeNumber>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlChangeNumber( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( MidiControlChangeNumber other )
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