using System;
using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Aggregate
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
            public MidiControlChangeValueCell CcValue { get; set; }
        }

        public ArticulationNameCell ArticulationName { get; }
        public ArticulationTypeCell ArticulationType { get; }
        public ColorIndexCell ColorIndex { get; }
        public GroupIndexCell GroupIndex { get; }

        public List<MidiNote> MidiNoteList { get; } = new List<MidiNote>();
        public List<MidiControlChange> MidiControlChangeList { get; } = new List<MidiControlChange>();
        public List<MidiProgramCell> MidiProgramChangeList { get; } = new List<MidiProgramCell>();

        public Row(
            ArticulationNameCell name,
            ArticulationTypeCell type,
            ColorIndexCell colorIndex,
            GroupIndexCell groupIndex
        )
        {
            ArticulationName = name ?? throw new ArgumentNullException( nameof( name ) );
            ArticulationType = type;
            ColorIndex       = colorIndex ?? new ColorIndexCell( ColorIndexCell.MinValue );
            GroupIndex       = groupIndex ?? new GroupIndexCell( GroupIndexCell.MinValue );
        }
    }
}