using System;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    /// <summary>
    /// Generic MIDI message data.
    /// </summary>
    public class MidiStatusCode : IMidiEventData, IEquatable<MidiStatusCode>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0xFF;

        #region Presets
        public static readonly MidiStatusCode NoteOn = new MidiStatusCode( 0x90 );
        public static readonly MidiStatusCode ControlChange = new MidiStatusCode( 0xB0 );
        public static readonly MidiStatusCode ProgramChange = new MidiStatusCode( 0xC0 );
        #endregion

        public int Value { get; }

        public MidiStatusCode( int value )
        {
            RangeValidateHelper.ValidateIntRange( value, MinValue, MaxValue );
            Value  = value;
        }

        public bool Equals( MidiStatusCode other )
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