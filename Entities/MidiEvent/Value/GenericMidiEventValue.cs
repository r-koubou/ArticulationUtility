using System;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    /// <summary>
    /// Generic MIDI message data.
    /// </summary>
    public class GenericMidiEventValue : IMidiEventData, IEquatable<GenericMidiEventValue>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public static GenericMidiEventValue Zero()
        {
            return new GenericMidiEventValue( 0 );
        }

        public GenericMidiEventValue( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value  = value;
        }

        public bool Equals( GenericMidiEventValue other )
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