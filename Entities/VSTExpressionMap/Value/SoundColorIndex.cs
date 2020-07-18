using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    public class SoundSlotColorIndex : IEquatable<SoundSlotColorIndex>
    {
        public static readonly int MinValue = 0;
        public static readonly int MaxValue = 15;
        public int Value { get; }

        public SoundSlotColorIndex( int groupValue )
        {
            RangeValidateHelper.ValidateIntRange( groupValue, MinValue, MaxValue );
            Value = groupValue;
        }

        public bool Equals( SoundSlotColorIndex other )
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