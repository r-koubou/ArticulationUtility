using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiProgramChangeChannel : IMidiEventData, IEquatable<MidiProgramChangeChannel>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x0F;

        public int Value { get; }

        public MidiProgramChangeChannel( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( MidiProgramChangeChannel other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}