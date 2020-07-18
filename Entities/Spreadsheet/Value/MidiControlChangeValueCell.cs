using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class MidiControlChangeValueCell : IEquatable<MidiControlChangeValueCell>
    {
        public static readonly int MinValue = 0x00;
        public static readonly int MaxValue = 0x7f;

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