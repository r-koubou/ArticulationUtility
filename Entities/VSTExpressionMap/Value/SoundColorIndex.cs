using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    public class SoundSlotColorIndex : IEquatable<SoundSlotColorIndex>
    {
        public const int MinValue = 0;    // 0: default color
        public const int MaxValue = 16;   // 1~16: User color
        public int Value { get; }

        public SoundSlotColorIndex( int groupValue )
        {
            RangeValidateHelper.ValidateIntRange( groupValue, MinValue, MaxValue );
            Value = groupValue;
        }

        public bool Equals( [AllowNull] SoundSlotColorIndex other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}