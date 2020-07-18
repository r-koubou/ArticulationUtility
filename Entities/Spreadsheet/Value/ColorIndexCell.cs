using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class ColorIndexCell : IEquatable<ColorIndexCell>
    {
        public int Value { get; }

        public ColorIndexCell( int index )
        {
            RangeValidateHelper.ValidateIntMinValue( index, 0 );
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