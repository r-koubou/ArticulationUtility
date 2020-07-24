using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class MidiProgramChangeLsbCellToPcLsb
        : IMidiEventAdapter<MidiProgramChangeLsbCell, MidiLeastSignificantByte>
    {
        public MidiLeastSignificantByte Convert( MidiProgramChangeLsbCell source )
        {
            return new MidiLeastSignificantByte( source.Value );
        }
    }
}