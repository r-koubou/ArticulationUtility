using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value;

namespace ArticulationUtility.Adapters.MidiEvent.Spreadsheet.Compatibility.Ver_0_8
{
    public class MidiNoteVelocityCellToVelocity : IMidiEventAdapter<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Convert( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}