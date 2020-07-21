using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent.Spreadsheet
{
    public class MidiNoteVelocityCellToVelocity : IMidiEventAdapter<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Convert( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}