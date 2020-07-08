using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.Spreadsheet.Value
{
    public class MidiNoteNumberCell : IEquatable<MidiNoteNumberCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiNoteNumberCell( int noteNumber )
        {
            ValueRangeValidateHelper.ValidateIntRange( noteNumber, MinValue, MaxValue );
            Value = noteNumber;
        }

        public bool Equals( MidiNoteNumberCell other )
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