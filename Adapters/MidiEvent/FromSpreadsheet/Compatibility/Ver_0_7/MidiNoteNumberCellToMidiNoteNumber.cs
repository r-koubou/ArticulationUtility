using System.Collections.Generic;

using ArticulationUtility.Entities;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_7
{
    public class MidiNoteNumberCellToMidiNoteNumber : IDataAdapter<MidiNoteNumberCell, MidiNoteNumber>
    {
        private static readonly List<string> NoteNameList;
        private static readonly List<string> NoteNumberList;

        static MidiNoteNumberCellToMidiNoteNumber()
        {
            NoteNameList   = MidiNoteNumberCell.GetNoteNameList();
            NoteNumberList = MidiNoteNumberCell.GetNoteNumberList();
        }

        /// <summary>
        /// Calculate the MIDI note number from given value.
        /// </summary>
        /// <returns>MIDI note number range (0~127). Otherwise -1.</returns>
        private static int IndexOf( MidiNoteNumberCell cell )
        {
            var cellValue = cell.Value;

            if( NoteNumberList.Contains( cell.Value ) )
            {
                return NoteNumberList.IndexOf( cell.Value );
            }

            if( NoteNameList.Contains( cellValue ) )
            {
                return NoteNameList.IndexOf( cell.Value );
            }

            if( int.TryParse( cellValue, out var noteNumber ) )
            {
                return noteNumber;
            }

            return -1;
        }

        public MidiNoteNumber Convert( MidiNoteNumberCell source )
        {
            int noteNumber = IndexOf( source );
            return new MidiNoteNumber( noteNumber );
        }
    }
}