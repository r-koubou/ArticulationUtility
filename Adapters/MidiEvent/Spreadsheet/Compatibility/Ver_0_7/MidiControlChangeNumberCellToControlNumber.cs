using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.Spreadsheet.Compatibility.Ver_0_7
{
    public class MidiControlChangeNumberCellToControlNumber : IMidiEventAdapter<MidiControlChangeNumberCell, MidiControlChangeNumber>
    {
        public MidiControlChangeNumber Convert( MidiControlChangeNumberCell source )
        {
            return new MidiControlChangeNumber( source.Value );
        }
    }
}