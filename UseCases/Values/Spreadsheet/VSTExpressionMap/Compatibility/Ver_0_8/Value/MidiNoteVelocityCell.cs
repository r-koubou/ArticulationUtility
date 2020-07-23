using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class MidiNoteVelocityCell : IEquatable<MidiNoteVelocityCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiNoteVelocityCell( int velocity )
        {
            RangeValidateHelper.ValidateIntRange( velocity, MinValue, MaxValue );
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