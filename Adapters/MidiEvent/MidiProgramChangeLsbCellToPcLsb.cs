using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
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