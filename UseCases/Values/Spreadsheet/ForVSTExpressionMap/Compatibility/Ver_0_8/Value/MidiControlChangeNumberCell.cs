using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class MidiControlChangeNumberCell : IEquatable<MidiControlChangeNumberCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public int Value { get; }

        public MidiControlChangeNumberCell( int ccNumber )
        {
            RangeValidateHelper.ValidateIntRange( ccNumber, MinValue, MaxValue );
            Value = ccNumber;
        }

        public bool Equals( [AllowNull] MidiControlChangeNumberCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}