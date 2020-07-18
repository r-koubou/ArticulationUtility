using System;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class MidiNoteVelocityCell : IEquatable<MidiNoteVelocityCell>
    {
        public static readonly int MinValue = 0x00;
        public static readonly int MaxValue = 0x7f;

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