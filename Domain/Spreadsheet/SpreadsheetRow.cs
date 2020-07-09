using System;
using System.Collections.Generic;

using ArticulationUtility.Domain.Spreadsheet.Value;

namespace ArticulationUtility.Domain.Spreadsheet
{
    public class SpreadsheetRow
    {
        public class MidiControlChange
        {
            public MidiControlChangeNumberCell CcNumber { get; set; }
            public MidiControlChangeNumberCell CcValue { get; set; }
        }

        public ArticulationNameCell ArticulationName { get; }
        public ColorIndexCell ColorIndex { get; }
        public MidiNoteNumberCell MidiNoteNumber { get; }
        public MidiNoteVelocityCell MidiNoteVelocity { get; }
        public List<MidiControlChange> MidiControlChangeList { get; } = new List<MidiControlChange>();

        public SpreadsheetRow(
            ArticulationNameCell name,
            ColorIndexCell colorIndex,
            MidiNoteNumberCell noteNumber,
            MidiNoteVelocityCell velocity,
            List<MidiControlChange> controlChangeList = null
        )
        {
            ArticulationName = name ?? throw new ArgumentNullException( nameof( name ) );
            ColorIndex       = colorIndex ?? throw new ArgumentNullException( nameof( colorIndex ) );
            MidiNoteNumber   = noteNumber;
            MidiNoteVelocity = velocity;

            if( controlChangeList != null )
            {
                MidiControlChangeList.AddRange( controlChangeList );
            }
        }
    }
}