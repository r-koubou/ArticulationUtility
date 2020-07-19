using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Adapters.MidiEvent
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