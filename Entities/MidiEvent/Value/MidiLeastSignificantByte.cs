using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiLeastSignificantByte : IMidiEventData, IEquatable<MidiLeastSignificantByte>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public static readonly MidiLeastSignificantByte Zero = new MidiLeastSignificantByte( 0 );

        public int Value { get; }

        public MidiLeastSignificantByte( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value = value;
        }

        public bool Equals( [AllowNull] MidiLeastSignificantByte other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}