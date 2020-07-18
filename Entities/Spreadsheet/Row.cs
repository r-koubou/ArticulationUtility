using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Row
    {
        public class MidiNote
        {
            public MidiNoteNumberCell Note { get; set; }
            public MidiNoteVelocityCell Velocity { get; set; }
        }

        public class MidiControlChange
        {
            public MidiControlChangeNumberCell CcNumber { get; set; }
            public MidiControlChangeNumberCell CcValue { get; set; }
        }

        public ArticulationNameCell ArticulationName { get; }
        public ArticulationTypeCell ArticulationType { get; }
        public ColorIndexCell ColorIndex { get; }
        public GroupIndexCell GroupIndex { get; }

        public List<MidiNoteNumberCell> MidiNoteList { get; } = new List<MidiNoteNumberCell>();
        public List<MidiControlChange> MidiControlChangeList { get; } = new List<MidiControlChange>();

        public Row(
            ArticulationNameCell name,
            ArticulationTypeCell type,
            ColorIndexCell colorIndex,
            GroupIndexCell groupIndex
        )
        {
            ArticulationName = name ?? throw new ArgumentNullException( nameof( name ) );
            ArticulationType = type;
            ColorIndex       = colorIndex ?? new ColorIndexCell( 0 );
            GroupIndex       = groupIndex ?? new GroupIndexCell( GroupIndexCell.MinValue );
        }
    }
}