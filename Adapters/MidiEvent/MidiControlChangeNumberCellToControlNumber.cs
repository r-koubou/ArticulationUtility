using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
{
    public class MidiControlChangeNumberCellToControlNumber : IMidiEventAdapter<MidiControlChangeNumberCell, MidiControlNumber>
    {
        public MidiControlNumber Convert( MidiControlChangeNumberCell source )
        {
            return new MidiControlNumber( source.Value );
        }
    }
}