using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class MidiProgramChangeMsbCellToPcMsb
        : IMidiEventAdapter<MidiProgramChangeMsbCell, MidiMostSignificantByte>
    {
        public MidiMostSignificantByte Convert( MidiProgramChangeMsbCell source )
        {
            return new MidiMostSignificantByte( source.Value );
        }
    }
}