using System;

namespace Spreadsheet2Expressionmap.Converter.Entity.Value
{
    public class MidiControlNumber : IEquatable<MidiControlNumber>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlNumber( int value )
        {
            if( value < MinValue || value > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof( value ), value, MinValue, MaxValue );
            }

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