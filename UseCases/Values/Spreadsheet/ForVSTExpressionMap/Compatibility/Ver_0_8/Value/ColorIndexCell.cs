using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public const int MinValue = 0;
        public const int MaxValue = 255;
        public static readonly ColorIndexCell Default = new ColorIndexCell( MinValue );
        public int Value { get; }

        public ColorIndexCell( int index )
        {
            RangeValidateHelper.ValidateIntRange( index, MinValue, MaxValue );
            Value = index;
        }

        public bool Equals( [AllowNull] ColorIndexCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}