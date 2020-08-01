using System;
using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Aggregate
{
    public class Row
    {
        public class MidiNote
        {
            public MidiNoteNumberCell Note { get; set; }
                = new MidiNoteNumberCell( MidiNoteNumberCell.GetNoteNameList()[ 0 ] );
            public MidiNoteVelocityCell Velocity { get; set; }
                = new MidiNoteVelocityCell( MidiNoteVelocityCell.MinValue );
        }

        public class MidiControlChange
        {
            public MidiControlChangeNumberCell CcNumber { get; set; }
                = new MidiControlChangeNumberCell( MidiControlChangeNumberCell.MinValue );
            public MidiControlChangeValueCell CcValue { get; set; }
                = new MidiControlChangeValueCell( MidiControlChangeValueCell.MinValue );
        }

        public class MidiProgramChange
        {
            public MidiProgramChangeLsbCell Lsb { get; set; }
                = new MidiProgramChangeLsbCell( MidiProgramChangeLsbCell.MinValue );
            public MidiProgramChangeMsbCell Msb { get; set; }
                = new MidiProgramChangeMsbCell( MidiProgramChangeMsbCell.MinValue );
        }

        public ArticulationNameCell ArticulationName { get; }
        public ArticulationTypeCell ArticulationType { get; }
        public ColorIndexCell ColorIndex { get; }
        public GroupIndexCell GroupIndex { get; }

        public List<MidiNote> MidiNoteList { get; } = new List<MidiNote>();
        public List<MidiControlChange> MidiControlChangeList { get; } = new List<MidiControlChange>();
        public List<MidiProgramChange> MidiProgramChangeList { get; } = new List<MidiProgramChange>();

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