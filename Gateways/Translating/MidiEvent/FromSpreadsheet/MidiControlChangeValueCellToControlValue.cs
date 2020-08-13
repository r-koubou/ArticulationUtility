using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.Value;

namespace ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet
{
    public class MidiControlChangeValueCellToControlValue
        : IDataTranslator<MidiControlChangeValueCell, MidiControlChangeValue>
    {
        public MidiControlChangeValue Translate( MidiControlChangeValueCell source )
        {
            return new MidiControlChangeValue( source.Value );
        }
    }
}