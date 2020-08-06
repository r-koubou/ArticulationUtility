using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value;

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