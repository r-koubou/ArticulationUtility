using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.Spreadsheet.Value
{
    public class MidiControlChangeValueCell : IEquatable<MidiControlChangeValueCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlChangeValueCell( int ccNumber )
        {
            RangeValidateHelper.ValidateIntRange( ccNumber, MinValue, MaxValue );
            Value = ccNumber;
        }

        public bool Equals( MidiControlChangeValueCell other )
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