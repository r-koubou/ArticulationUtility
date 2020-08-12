using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Value
{
    public class KeySwitchPitch : IEquatable<KeySwitchPitch>
    {
        public const int MinValue = MidiNoteNumber.MinValue;
        public const int MaxValue = MidiNoteNumber.MaxValue;
        public int Value { get; }

        public KeySwitchPitch( int midiNoteNumber )
        {
            RangeValidateHelper.ValidateIntRange( midiNoteNumber, MinValue, MaxValue );
            Value = midiNoteNumber;
        }

        public bool Equals( [AllowNull] KeySwitchPitch other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}