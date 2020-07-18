using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public static readonly int MinValue = 0;
        public static readonly int MaxValue = Int32.MaxValue;

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