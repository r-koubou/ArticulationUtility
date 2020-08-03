using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiProgramChangeNumber : IMidiEventData, IEquatable<MidiProgramChangeNumber>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x0F;

        public int Value { get; }

        public MidiProgramChangeNumber( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( [AllowNull] MidiProgramChangeNumber other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}