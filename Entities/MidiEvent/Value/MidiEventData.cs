using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public abstract class MidiEventData : IMidiEventData, IEquatable<MidiEventData>
    {
        public int Value { get; }

        protected MidiEventData( int value, int min, int max )
        {
            RangeValidateHelper.ValidateIntRange( value, min, max );
            Value = value;
        }

        public bool Equals( [AllowNull] MidiEventData other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();

    }
}