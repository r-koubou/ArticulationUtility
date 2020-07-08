using System;

namespace ArticulationUtility.Domain.Spreadsheet.Value
{
    public class MidiNoteVelocityCell : IEquatable<MidiNoteVelocityCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiNoteVelocityCell( int velocity )
        {
            Value = velocity;
        }

        public bool Equals( MidiNoteVelocityCell other )
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