using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value;

namespace ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet
{
    public class MidiProgramCellToProgram
        : IDataTranslator<MidiProgramChangeCell, GenericMidiEvent>
    {
        public GenericMidiEvent Translate( MidiProgramChangeCell source )
        {
            return new GenericMidiEvent(
                MidiStatusCode.ProgramChange,
                new GenericMidiEventValue( source.Value ),
                GenericMidiEventValue.Zero()
            );
        }
    }
}