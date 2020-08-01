using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class MidiControlChangeNumberCellToControlNumber : IDataAdapter<MidiControlChangeNumberCell, MidiControlChangeNumber>
    {
        public MidiControlChangeNumber Convert( MidiControlChangeNumberCell source )
        {
            return new MidiControlChangeNumber( source.Value );
        }
    }
}