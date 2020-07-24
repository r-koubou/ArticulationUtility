using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class MidiNoteVelocityCellToVelocity : IMidiEventAdapter<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Convert( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}