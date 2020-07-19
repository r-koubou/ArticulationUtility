using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
{
    public class MidiNoteVelocityCellToVelocity : IMidiEventAdapter<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Convert( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}