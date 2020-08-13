using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.Value;

namespace ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet
{
    public class MidiNoteVelocityCellToVelocity : IDataTranslator<MidiNoteVelocityCell, MidiVelocity>
    {
        public MidiVelocity Translate( MidiNoteVelocityCell source )
        {
            return new MidiVelocity( source.Value );
        }
    }
}