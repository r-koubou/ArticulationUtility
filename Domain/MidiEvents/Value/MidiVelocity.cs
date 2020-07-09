using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.MidiEvents.Value
{
    public class MidiVelocity : IMidiEventData, IEquatable<MidiVelocity>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiVelocity( int velocity )
        {
            RangeValidateHelper.ValidateIntRange( velocity, MinValue, MaxValue );
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