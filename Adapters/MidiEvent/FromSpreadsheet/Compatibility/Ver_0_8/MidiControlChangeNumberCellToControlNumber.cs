using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class MidiControlChangeNumberCellToControlNumber : IMidiEventAdapter<MidiControlChangeNumberCell, MidiControlChangeNumber>
    {
        public MidiControlChangeNumber Convert( MidiControlChangeNumberCell source )
        {
            return new MidiControlChangeNumber( source.Value );
        }
    }
}