using System;

using ArticulationUtility.Domain.MidiEvents.Value;

namespace ArticulationUtility.Domain.VSTExpressionMap.Value
{
    public class SoundSlotColorIndex : IEquatable<SoundSlotColorIndex>
    {
        public const int MinValue = 0;
        public const int MaxValue = 15;
        public int Value { get; }

        public SoundSlotColorIndex( int groupValue )
        {
            if( groupValue < MinValue || groupValue > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(groupValue), groupValue, MinValue, MaxValue );
            }
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