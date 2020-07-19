using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue;
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