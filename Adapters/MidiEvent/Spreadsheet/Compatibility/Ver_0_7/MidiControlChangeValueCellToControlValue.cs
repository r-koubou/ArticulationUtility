using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.Spreadsheet.Compatibility.Ver_0_7
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