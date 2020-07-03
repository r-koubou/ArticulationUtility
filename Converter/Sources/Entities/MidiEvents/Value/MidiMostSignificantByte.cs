using System;

namespace Spreadsheet2Expressionmap.Converter.Entities.MidiEvents.Value
{
    public class MidiMostSignificantByte : IMidiEventData, IEquatable<MidiMostSignificantByte>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiMostSignificantByte( int value )
        {
            if( value < MinValue || value > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(value), value, MinValue, MaxValue );
            }
            Value = value;
        }

        public bool Equals( MidiMostSignificantByte other )
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