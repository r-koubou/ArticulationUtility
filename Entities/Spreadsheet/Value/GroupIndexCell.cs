using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class GroupIndexCell : IEquatable<GroupIndexCell>
    {
        public static readonly int MinValue = 1;
        public static readonly int MaxValue = 16;

        public int Value { get; }

        public GroupIndexCell( int index )
        {
            RangeValidateHelper.ValidateIntRange( index, MinValue, MaxValue );
            Value = index;
        }

        public bool Equals( GroupIndexCell other )
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