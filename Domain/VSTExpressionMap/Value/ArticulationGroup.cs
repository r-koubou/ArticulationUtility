using System;

using VSTExpressionMapTools.Domain.MidiEvents.Value;

namespace VSTExpressionMapTools.Domain.VSTExpressionMap.Value
{
    public class ArticulationGroup : IEquatable<ArticulationGroup>
    {
        public const int MinValue = 1;
        public const int MaxValue = 4;
        public int Value { get; }

        public ArticulationGroup( int groupValue )
        {
            if( groupValue < MinValue || groupValue > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(groupValue), groupValue, MinValue, MaxValue );
            }
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