using System;
using System.Collections.Generic;

using ArticulationUtility.Domain.Spreadsheet.Value;

namespace ArticulationUtility.Domain.Spreadsheet
{
    public class SpreadsheetRow
    {
        public struct MidiNote
        {
            public MidiNoteNumberCell Note { get; set; }
            public MidiNoteVelocityCell Velocity { get; set; }
        }

        public struct MidiControlChange
        {
            public MidiControlChangeNumberCell CcNumber { get; set; }
            public MidiControlChangeNumberCell CcValue { get; set; }
        }

        public ArticulationNameCell ArticulationName { get; }
        public ArticulationTypeCell ArticulationType { get; }
        public ColorIndexCell ColorIndex { get; }
        public List<MidiNoteNumberCell> MidiNoteList { get; } = new List<MidiNoteNumberCell>();
        public List<MidiControlChange> MidiControlChangeList { get; } = new List<MidiControlChange>();

        public SpreadsheetRow(
            ArticulationNameCell name,
            ArticulationTypeCell type,
            ColorIndexCell colorIndex
        )
        {
            ArticulationName = name ?? throw new ArgumentNullException( nameof( name ) );
            ArticulationType = type;
            ColorIndex       = colorIndex ?? throw new ArgumentNullException( nameof( colorIndex ) );
        }
    }
}