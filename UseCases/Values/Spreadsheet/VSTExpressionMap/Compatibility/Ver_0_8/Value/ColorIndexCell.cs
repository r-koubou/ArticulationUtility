using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public const int MinValue = 0;
        public const int MaxValue = 255;
        public int Value { get; }

        public ColorIndexCell( int index )
        {
            RangeValidateHelper.ValidateIntRange( index, MinValue, MaxValue );
            Value = index;
        }

        public bool Equals( ColorIndexCell other )
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