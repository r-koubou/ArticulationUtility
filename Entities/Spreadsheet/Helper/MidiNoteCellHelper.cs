using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Helper;
using ArticulationUtility.Entities.MidiEvents.Value;
using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet.Helper
{
    public static class MidiNoteCellHelper
    {
        private static readonly List<string> NoteNameList;
        private static readonly List<string> NoteNumberList;

        static MidiNoteCellHelper()
        {
            NoteNameList   = MidiNoteNumberCell.GetNoteNameList();
            NoteNumberList = MidiNoteNumberCell.GetNoteNumberList();
        }

        /// <summary>
        /// Calculate the MIDI note number from given value.
        /// </summary>
        /// <returns>MIDI note number range (0~127). Otherwise -1.</returns>
        public static int IndexOf( MidiNoteNumberCell cell )
        {
            var cellValue = cell.Value;

            if( NoteNumberList.Contains( cell.Value ) )
            {
                return NoteNumberList.IndexOf( cell.Value );
            }

            if( NoteNumberList.Contains( cellValue ) )
            {
                return NoteNumberList.IndexOf( cell.Value );
            }

            if( int.TryParse( cellValue, out var noteNumber ) )
            {
                return noteNumber;
            }

            return -1;
        }
    }
}