using System;
using System.Collections.Generic;
using System.Linq;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiNoteName : IEquatable<MidiNoteName>
    {
        #region Note names
        public static readonly string C_M2 = "C-2";
        public static readonly string C_Sharp_M2 = "C#-2";
        public static readonly string D_M2 = "D-2";
        public static readonly string D_Sharp_M2 = "D#-2";
        public static readonly string E_M2 = "E-2";
        public static readonly string F_M2 = "F-2";
        public static readonly string F_Sharp_M2 = "F#-2";
        public static readonly string G_M2 = "G-2";
        public static readonly string G_Sharp_M2 = "G#-2";
        public static readonly string A_M2 = "A-2";
        public static readonly string A_Sharp_M2 = "A#-2";
        public static readonly string B_M2 = "B-2";
        public static readonly string C_M1 = "C-1";
        public static readonly string C_Sharp_M1 = "C#-1";
        public static readonly string D_M1 = "D-1";
        public static readonly string D_Sharp_M1 = "D#-1";
        public static readonly string E_M1 = "E-1";
        public static readonly string F_M1 = "F-1";
        public static readonly string F_Sharp_M1 = "F#-1";
        public static readonly string G_M1 = "G-1";
        public static readonly string G_Sharp_M1 = "G#-1";
        public static readonly string A_M1 = "A-1";
        public static readonly string A_Sharp_M1 = "A#-1";
        public static readonly string B_M1 = "B-1";
        public static readonly string C_0 = "C0";
        public static readonly string C_Sharp_0 = "C#0";
        public static readonly string D_0 = "D0";
        public static readonly string D_Sharp_0 = "D#0";
        public static readonly string E_0 = "E0";
        public static readonly string F_0 = "F0";
        public static readonly string F_Sharp_0 = "F#0";
        public static readonly string G_0 = "G0";
        public static readonly string G_Sharp_0 = "G#0";
        public static readonly string A_0 = "A0";
        public static readonly string A_Sharp_0 = "A#0";
        public static readonly string B_0 = "B0";
        public static readonly string C_1 = "C1";
        public static readonly string C_Sharp_1 = "C#1";
        public static readonly string D_1 = "D1";
        public static readonly string D_Sharp_1 = "D#1";
        public static readonly string E_1 = "E1";
        public static readonly string F_1 = "F1";
        public static readonly string F_Sharp_1 = "F#1";
        public static readonly string G_1 = "G1";
        public static readonly string G_Sharp_1 = "G#1";
        public static readonly string A_1 = "A1";
        public static readonly string A_Sharp_1 = "A#1";
        public static readonly string B_1 = "B1";
        public static readonly string C_2 = "C2";
        public static readonly string C_Sharp_2 = "C#2";
        public static readonly string D_2 = "D2";
        public static readonly string D_Sharp_2 = "D#2";
        public static readonly string E_2 = "E2";
        public static readonly string F_2 = "F2";
        public static readonly string F_Sharp_2 = "F#2";
        public static readonly string G_2 = "G2";
        public static readonly string G_Sharp_2 = "G#2";
        public static readonly string A_2 = "A2";
        public static readonly string A_Sharp_2 = "A#2";
        public static readonly string B_2 = "B2";
        public static readonly string C_3 = "C3";
        public static readonly string C_Sharp_3 = "C#3";
        public static readonly string D_3 = "D3";
        public static readonly string D_Sharp_3 = "D#3";
        public static readonly string E_3 = "E3";
        public static readonly string F_3 = "F3";
        public static readonly string F_Sharp_3 = "F#3";
        public static readonly string G_3 = "G3";
        public static readonly string G_Sharp_3 = "G#3";
        public static readonly string A_3 = "A3";
        public static readonly string A_Sharp_3 = "A#3";
        public static readonly string B_3 = "B3";
        public static readonly string C_4 = "C4";
        public static readonly string C_Sharp_4 = "C#4";
        public static readonly string D_4 = "D4";
        public static readonly string D_Sharp_4 = "D#4";
        public static readonly string E_4 = "E4";
        public static readonly string F_4 = "F4";
        public static readonly string F_Sharp_4 = "F#4";
        public static readonly string G_4 = "G4";
        public static readonly string G_Sharp_4 = "G#4";
        public static readonly string A_4 = "A4";
        public static readonly string A_Sharp_4 = "A#4";
        public static readonly string B_4 = "B4";
        public static readonly string C_5 = "C5";
        public static readonly string C_Sharp_5 = "C#5";
        public static readonly string D_5 = "D5";
        public static readonly string D_Sharp_5 = "D#5";
        public static readonly string E_5 = "E5";
        public static readonly string F_5 = "F5";
        public static readonly string F_Sharp_5 = "F#5";
        public static readonly string G_5 = "G5";
        public static readonly string G_Sharp_5 = "G#5";
        public static readonly string A_5 = "A5";
        public static readonly string A_Sharp_5 = "A#5";
        public static readonly string B_5 = "B5";
        public static readonly string C_6 = "C6";
        public static readonly string C_Sharp_6 = "C#6";
        public static readonly string D_6 = "D6";
        public static readonly string D_Sharp_6 = "D#6";
        public static readonly string E_6 = "E6";
        public static readonly string F_6 = "F6";
        public static readonly string F_Sharp_6 = "F#6";
        public static readonly string G_6 = "G6";
        public static readonly string G_Sharp_6 = "G#6";
        public static readonly string A_6 = "A6";
        public static readonly string A_Sharp_6 = "A#6";
        public static readonly string B_6 = "B6";
        public static readonly string C_7 = "C7";
        public static readonly string C_Sharp_7 = "C#7";
        public static readonly string D_7 = "D7";
        public static readonly string D_Sharp_7 = "D#7";
        public static readonly string E_7 = "E7";
        public static readonly string F_7 = "F7";
        public static readonly string F_Sharp_7 = "F#7";
        public static readonly string G_7 = "G7";
        public static readonly string G_Sharp_7 = "G#7";
        public static readonly string A_7 = "A7";
        public static readonly string A_Sharp_7 = "A#7";
        public static readonly string B_7 = "B7";
        public static readonly string C_8 = "C8";
        public static readonly string C_Sharp_8 = "C#8";
        public static readonly string D_8 = "D8";
        public static readonly string D_Sharp_8 = "D#8";
        public static readonly string E_8 = "E8";
        public static readonly string F_8 = "F8";
        public static readonly string F_Sharp_8 = "F#8";
        public static readonly string G_8 = "G8";
        #endregion Note names

        /// <summary>
        /// A list containing the index and scale name of the list in sequential form.
        /// </summary>
        private static readonly IReadOnlyList<string> NoteNameList = new List<string>()
        {
            C_M2,
            C_Sharp_M2,
            D_M2,
            D_Sharp_M2,
            E_M2,
            F_M2,
            F_Sharp_M2,
            G_M2,
            G_Sharp_M2,
            A_M2,
            A_Sharp_M2,
            B_M2,
            C_M1,
            C_Sharp_M1,
            D_M1,
            D_Sharp_M1,
            E_M1,
            F_M1,
            F_Sharp_M1,
            G_M1,
            G_Sharp_M1,
            A_M1,
            A_Sharp_M1,
            B_M1,
            C_0,
            C_Sharp_0,
            D_0,
            D_Sharp_0,
            E_0,
            F_0,
            F_Sharp_0,
            G_0,
            G_Sharp_0,
            A_0,
            A_Sharp_0,
            B_0,
            C_1,
            C_Sharp_1,
            D_1,
            D_Sharp_1,
            E_1,
            F_1,
            F_Sharp_1,
            G_1,
            G_Sharp_1,
            A_1,
            A_Sharp_1,
            B_1,
            C_2,
            C_Sharp_2,
            D_2,
            D_Sharp_2,
            E_2,
            F_2,
            F_Sharp_2,
            G_2,
            G_Sharp_2,
            A_2,
            A_Sharp_2,
            B_2,
            C_3,
            C_Sharp_3,
            D_3,
            D_Sharp_3,
            E_3,
            F_3,
            F_Sharp_3,
            G_3,
            G_Sharp_3,
            A_3,
            A_Sharp_3,
            B_3,
            C_4,
            C_Sharp_4,
            D_4,
            D_Sharp_4,
            E_4,
            F_4,
            F_Sharp_4,
            G_4,
            G_Sharp_4,
            A_4,
            A_Sharp_4,
            B_4,
            C_5,
            C_Sharp_5,
            D_5,
            D_Sharp_5,
            E_5,
            F_5,
            F_Sharp_5,
            G_5,
            G_Sharp_5,
            A_5,
            A_Sharp_5,
            B_5,
            C_6,
            C_Sharp_6,
            D_6,
            D_Sharp_6,
            E_6,
            F_6,
            F_Sharp_6,
            G_6,
            G_Sharp_6,
            A_6,
            A_Sharp_6,
            B_6,
            C_7,
            C_Sharp_7,
            D_7,
            D_Sharp_7,
            E_7,
            F_7,
            F_Sharp_7,
            G_7,
            G_Sharp_7,
            A_7,
            A_Sharp_7,
            B_7,
            C_8,
            C_Sharp_8,
            D_8,
            D_Sharp_8,
            E_8,
            F_8,
            F_Sharp_8,
            G_8,
        };

        public string Value { get; }

        public MidiNoteName( string noteName )
        {
            StringHelper.ValidateNullOrTrimEmpty( noteName );

            if( NoteNameList.Contains( noteName ) )
            {
                Value = noteName;
                return;
            }

            if( int.TryParse( noteName, out var number ) )
            {
                RangeValidateHelper.ValidateIntRange( number, MidiNoteNumber.MinValue, MidiNoteNumber.MaxValue );
                Value = NoteNameList[ number ];
                return;
            }

            throw new InvalidNameException( nameof( noteName ) );
        }

        public MidiNoteNumber ToMidiNoteNumber()
        {
            var number =
                NoteNameList.Select( ( n, i ) => new { name = n, index = i } )
                            .Where( obj => obj.name == Value );

            return new MidiNoteNumber( number.First().index );
        }

        public bool Equals( MidiNoteName other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}