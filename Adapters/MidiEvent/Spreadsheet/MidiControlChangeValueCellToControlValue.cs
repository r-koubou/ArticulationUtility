using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent.Spreadsheet
{
    public class MidiControlChangeValueCellToControlValue
        : IMidiEventAdapter<MidiControlChangeValueCell, MidiControlChangeValue>
    {
        public MidiControlChangeValue Convert( MidiControlChangeValueCell source )
        {
            return new MidiControlChangeValue( source.Value );
        }
    }
}