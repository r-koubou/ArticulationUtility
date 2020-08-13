using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.Value;

namespace ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet
{
    public class MidiControlChangeNumberCellToControlNumber : IDataTranslator<MidiControlChangeNumberCell, MidiControlChangeNumber>
    {
        public MidiControlChangeNumber Translate( MidiControlChangeNumberCell source )
        {
            return new MidiControlChangeNumber( source.Value );
        }
    }
}