using System.Collections.Generic;
using System.Collections.ObjectModel;

using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Entity.Helper
{
    /// <summary>
    /// Helper class for <seealso cref="MidiNoteNumber"/>
    /// </summary>
    public static class MidiNoteHelper
    {
        #region Mapping Table

        /// <summary>
        /// A list containing the index and scale name of the list in sequential form.
        /// </summary>
        private static readonly List<string> NoteNameList
            = new List<string>()
            {
                "C-2",
                "C#-2",
                "D-2",
                "D#-2",
                "E-2",
                "F-2",
                "F#-2",
                "G-2",
                "G#-2",
                "A-2",
                "A#-2",
                "B-2",
                "C-1",
                "C#-1",
                "D-1",
                "D#-1",
                "E-1",
                "F-1",
                "F#-1",
                "G-1",
                "G#-1",
                "A-1",
                "A#-1",
                "B-1",
                "C0",
                "C#0",
                "D0",
                "D#0",
                "E0",
                "F0",
                "F#0",
                "G0",
                "G#0",
                "A0",
                "A#0",
                "B0",
                "C1",
                "C#1",
                "D1",
                "D#1",
                "E1",
                "F1",
                "F#1",
                "G1",
                "G#1",
                "A1",
                "A#1",
                "B1",
                "C2",
                "C#2",
                "D2",
                "D#2",
                "E2",
                "F2",
                "F#2",
                "G2",
                "G#2",
                "A2",
                "A#2",
                "B2",
                "C3",
                "C#3",
                "D3",
                "D#3",
                "E3",
                "F3",
                "F#3",
                "G3",
                "G#3",
                "A3",
                "A#3",
                "B3",
                "C4",
                "C#4",
                "D4",
                "D#4",
                "E4",
                "F4",
                "F#4",
                "G4",
                "G#4",
                "A4",
                "A#4",
                "B4",
                "C5",
                "C#5",
                "D5",
                "D#5",
                "E5",
                "F5",
                "F#5",
                "G5",
                "G#5",
                "A5",
                "A#5",
                "B5",
                "C6",
                "C#6",
                "D6",
                "D#6",
                "E6",
                "F6",
                "F#6",
                "G6",
                "G#6",
                "A6",
                "A#6",
                "B6",
                "C7",
                "C#7",
                "D7",
                "D#7",
                "E7",
                "F7",
                "F#7",
                "G7",
                "G#7",
                "A7",
                "A#7",
                "B7",
                "C8",
                "C#8",
                "D8",
                "D#8",
                "E8",
                "F8",
                "F#8",
                "G8",
            };

        /// <summary>
        /// A table mapping MIDI note numbers that can be represented as integers from a scale name.
        /// </summary>
        private static readonly IReadOnlyDictionary<string, MidiNoteNumber> NoteNameToNoteNumberMapper;

        #endregion

        /// <summary>
        /// Static initializer
        /// </summary>
        static MidiNoteHelper()
        {
            var mapper = new Dictionary<string, MidiNoteNumber>();

            // { "NoteName": MidiNoteNumber( i ) }
            // { "NoteName (octave)": MidiNoteNumber( i ) }
            for( var i = 0; i < NoteNameList.Count; i++ )
            {
                var midiNote = new MidiNoteNumber( i );
                mapper[ NoteNameList[ i ] ] = midiNote;
                mapper[ NoteNameList[ i ] + $" ({i})" ] = midiNote;
            }

            NoteNameToNoteNumberMapper = mapper;
        }

        /// <summary>
        /// Create an instance from a musical scale name.
        /// </summary>
        /// <param name="noteName">
        /// MIDI note names that are represented in most DAWs.
        /// For example, the "scale name + octave" format, such as C-1, C#0, D1.
        /// </param>
        /// <returns>A generated instance.</returns>
        public static MidiNoteNumber FromNoteName( string noteName )
        {
            if( string.IsNullOrEmpty( noteName ) )
            {
                throw new MidiNoteNotFoundException( $"{nameof(noteName)} is null or empty." );
            }
            else if( !NoteNameToNoteNumberMapper.ContainsKey( noteName ) )
            {
                throw new MidiNoteNotFoundException( noteName );
            }
            return NoteNameToNoteNumberMapper[ noteName ];
        }

        /// <summary>
        /// Convert the given MidiNoteNumber to a string in musical scale name format.
        /// </summary>
        /// <returns name="noteName">
        /// MIDI note name that are represented in most DAWs.
        /// For example, the "scale name + octave" format, such as C-1, C#0, D1.
        /// </returns>
        public static string ToNoteName( MidiNoteNumber note )
        {
            if( note == null )
            {
                throw new MidiNoteNotFoundException( $"{nameof(note)} is null" );
            }
            return NoteNameList[ note.Value ];
        }

    }
}