using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class MidiControlChangeNumberCell : IEquatable<MidiControlChangeNumberCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiControlChangeNumberCell( int ccNumber )
        {
            RangeValidateHelper.ValidateIntRange( ccNumber, MinValue, MaxValue );
            Value = ccNumber;
        }

        public bool Equals( MidiControlChangeNumberCell other )
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