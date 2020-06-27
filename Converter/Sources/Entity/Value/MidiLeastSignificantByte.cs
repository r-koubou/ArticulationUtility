using System;

namespace Spreadsheet2Expressionmap.Converter.Entity.Value
{
    public class MidiLeastSignificantByte : IEquatable<MidiLeastSignificantByte>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiLeastSignificantByte( int value )
        {
            if( value < MinValue || value > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(value), value, MinValue, MaxValue );
            }
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