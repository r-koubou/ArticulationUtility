using System;
using System.Collections.Generic;

using ArticulationUtility.Domain.MidiEvents;

namespace ArticulationUtility.Domain.VSTExpressionMap
{
    /// <summary>
    /// Represents the Output Mapping of the Expression Map.
    /// </summary>
    public class OutputMapping
    {
        protected List<IMidiEvent<IMidiEventData, IMidiEventData>> EventList { get; }
            = new List<IMidiEvent<IMidiEventData, IMidiEventData>>();

        public OutputMapping()
        {
        }

        /// <summary>
        /// Add a MIDI event for mapping
        /// </summary>
        /// <param name="midiEvent">A MIDI event</param>
        public OutputMapping AddMidiEvent( IMidiEvent<IMidiEventData, IMidiEventData> midiEvent )
        {
            if( midiEvent == null )
            {
                throw new ArgumentNullException( $"{nameof( midiEvent )}" );
            }
            EventList.Add( midiEvent );

            return this;
        }

        /// <summary>
        /// Remove all added MIDI events from the mapping.
        /// </summary>
        public void ClearMidiEvent()
        {
            EventList.Clear();
        }

        /// <summary>
        /// Get a list of all mapped MIDI events.
        /// </summary>
        /// <returns></returns>
        public List<IMidiEvent<IMidiEventData, IMidiEventData>> GetEventList()
        {
            return new List<IMidiEvent<IMidiEventData, IMidiEventData>>( EventList );
        }
    }
}