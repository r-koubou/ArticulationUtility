using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
{
    public class MidiControlChangeValueCellToControlValue
        : IMidiEventAdapter<MidiControlChangeValueCell, MidiControlValue>
    {
        public MidiControlValue Convert( MidiControlChangeValueCell source )
        {
            return new MidiControlValue( source.Value );
        }
    }
}