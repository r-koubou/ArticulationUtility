using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    /// <summary>
    /// Generic MIDI message data.
    /// </summary>
    public class GenericMidiEventValue : IMidiEventData, IEquatable<GenericMidiEventValue>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0xFF;

        public static readonly GenericMidiEventValue Zero = new GenericMidiEventValue( 0 );

        public int Value { get; }

        public GenericMidiEventValue( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value  = value;
        }

        public bool Equals( [AllowNull] GenericMidiEventValue other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();

    }
}