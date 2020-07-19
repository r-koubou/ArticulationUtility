using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
{
    public class MidiControlChangeNumberCellToControlNumber : IMidiEventAdapter<MidiControlChangeNumberCell, MidiControlChangeNumber>
    {
        public MidiControlChangeNumber Convert( MidiControlChangeNumberCell source )
        {
            return new MidiControlChangeNumber( source.Value );
        }
    }
}