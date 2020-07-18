using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    public class ArticulationGroup : IEquatable<ArticulationGroup>
    {
        public static readonly int MinValue = 1;
        public static readonly int MaxValue = 4;
        public int Value { get; }

        public ArticulationGroup( int groupValue )
        {
            RangeValidateHelper.ValidateIntRange( groupValue, MinValue, MaxValue );
            Value = groupValue;
        }

        public bool Equals( ArticulationGroup other )
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