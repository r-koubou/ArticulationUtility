using System;

namespace VSTExpressionMap.Core.Entities.MidiEvents.Value
{
    public class MidiVelocity : IMidiEventData, IEquatable<MidiVelocity>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiVelocity( int velocity )
        {
            if( velocity < MinValue || velocity > MaxValue )
            {
                throw new ValueOutOfRangeException( nameof(velocity), velocity, MinValue, MaxValue );
            }
            Value = velocity;
        }

        public bool Equals( MidiVelocity other )
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