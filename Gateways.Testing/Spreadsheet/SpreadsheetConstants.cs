namespace ArticulationUtility.Gateways.Testing.Spreadsheet
{
    public static  class SpreadsheetConstants
    {
        public static readonly string COLUMN_NAME                 = "Name";
        public static readonly string COLUMN_COLOR                = "Color";
        public static readonly string COLUMN_ARTICULATION         = "Articulation";
        public static readonly string COLUMN_ARTICULATION_TYPE    = "Articulation Type";
        public static readonly string COLUMN_GROUP                = "Group";
        public static readonly string COLUMN_PROGRAM_NUM          = "Program Change";
        public static readonly string COLUMN_MIDI_NOTE            = "MIDI Note";
        public static readonly string COLUMN_MIDI_VELOCITY        = "Velocity";
        public static readonly string COLUMN_MIDI_CC              = "CC No";
        public static readonly string COLUMN_MIDI_CC_VALUE        = "CC Value";
        public static readonly string COLUMN_MIDI_PC_LSB          = "PC LSB";
        public static readonly string COLUMN_MIDI_PC_MSB          = "PC MSB";

        // List definition sheet name
        public static readonly string LIST_DEFINITION_SHEETNAME   = "DO NOT MODIFY!";

        // Start of data entry row index (2==header)
        public static readonly int HEADER_ROW_INDEX = 2;
        public static readonly int START_ROW_INDEX = 3;
    }
}