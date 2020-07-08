using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.Spreadsheet.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public int Value { get; }

        public ColorIndexCell( int index )
        {
            ValueRangeValidateHelper.ValidateIntMinValue( index, 0 );
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