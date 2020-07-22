namespace ArticulationUtility.Gateways.Spreadsheet.Compatibility.Ver_0_7
{
    public static  class SpreadsheetConstants
    {

        public static readonly string ColumnName = "Name";
        public static readonly string ColumnColor = "Color";
        public static readonly string ColumnArticulation = "Articulation";
        public static readonly string ColumnArticulationType = "Articulation Type";
        public static readonly string ColumnGroup = "Group";
        public static readonly string ColumnProgramChange = "Program Change";
        public static readonly string ColumnMidiNote = "MIDI Note";
        public static readonly string ColumnMidiVelocity = "Velocity";
        public static readonly string ColumnMidiCc = "CC No";
        public static readonly string ColumnMidiCcValue = "CC Value";
        public static readonly string ColumnMidiPcLsb = "PC LSB";
        public static readonly string ColumnMidiPcMsb = "PC MSB";

        // List definition sheet name
        public static readonly string DefinitionSheetName   = "DO NOT MODIFY!";

        // Position of Output name cell
        public static readonly int RowOutputIndex = 0;
        public static readonly int ColumnOutputNameIndex = 1;

        // Start of data entry row index (2==header)
        public static readonly int HeaderRowIndex = 2;
        public static readonly int StartRowIndex = 3;
    }
}