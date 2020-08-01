using System;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiVelocity : IMidiEventData, IEquatable<MidiVelocity>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public int Value { get; }

        public MidiVelocity( int velocity )
        {
            RangeValidateHelper.ValidateIntRange( velocity, MinValue, MaxValue );
            Value = velocity;
        }

        public bool Equals( MidiVelocity other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}