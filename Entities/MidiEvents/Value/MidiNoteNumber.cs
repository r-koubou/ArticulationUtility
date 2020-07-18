using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.MidiEvents.Value
{
    public class MidiNoteNumber : IMidiEventData, IEquatable<MidiNoteNumber>
    {
        public static readonly int MinValue = 0x00;
        public static readonly int MaxValue = 0x7f;

        public int Value { get; }

        public MidiNoteNumber( int noteNumber )
        {
            RangeValidateHelper.ValidateIntRange( noteNumber, MinValue, MaxValue );
            Value = noteNumber;
        }

        public bool Equals( MidiNoteNumber other )
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