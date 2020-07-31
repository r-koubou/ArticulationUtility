using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value
{
    public class MidiControlChangeValueCell : IEquatable<MidiControlChangeValueCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public int Value { get; }

        public MidiControlChangeValueCell( int ccValue )
        {
            RangeValidateHelper.ValidateIntRange( ccValue, MinValue, MaxValue );
            Value = ccValue;
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