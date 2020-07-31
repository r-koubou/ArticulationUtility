using ArticulationUtility.Entities;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class MidiNoteVelocityCellToVelocity : IDataAdapter<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Convert( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}