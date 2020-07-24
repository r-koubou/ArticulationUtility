using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class MidiProgramCellToProgram
        : IMidiEventAdapter<MidiProgramCell, GenericMidiEvent>
    {
        public GenericMidiEvent Convert( MidiProgramCell source )
        {
            return new GenericMidiEvent(
                MidiStatusCode.ProgramChange,
                new GenericMidiEventValue( source.Value ),
                GenericMidiEventValue.Zero()
            );
        }
    }
}