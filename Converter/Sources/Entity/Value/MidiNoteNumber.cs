using System;

namespace Spreadsheet2Expressionmap.Converter.Entity.Value
{
    public class MidiNoteNumber : IEquatable<MidiNoteNumber>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiNoteNumber( int noteNumber )
        {
            if( noteNumber < MinValue || noteNumber > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(noteNumber), noteNumber, MinValue, MaxValue );
            }
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