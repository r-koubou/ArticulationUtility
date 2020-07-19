using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiNoteNumber : IMidiEventData, IEquatable<MidiNoteNumber>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

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