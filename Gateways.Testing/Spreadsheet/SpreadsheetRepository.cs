using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Entities.Spreadsheet.Value;

using ExcelDataReader;

using SourceSheet   = System.Data.DataTable;
using SourceRows    = System.Data.DataRowCollection;
using SourceRow     = System.Data.DataRow;
using SourceColumns = System.Data.DataColumnCollection;
using SourceColumn  = System.Data.DataColumn;

namespace ArticulationUtility.Gateways.Testing.Spreadsheet
{
    public class SpreadsheetRepository : ISpreadsheetRepository
    {
        private class CellContext
        {
            public int RowIndex;
            public SourceSheet Sheet;
            public SourceRow Row;
        }

        private class ArticulationCellGroup
        {
            public ArticulationNameCell NameCell { get; set; }
            public ArticulationTypeCell TypeCell { get; set; }
            public ColorIndexCell ColorIndexCell { get; set; }
            public GroupIndexCell GroupIndexCell { get; set; }
        }

        public string Path { get; }

        static SpreadsheetRepository()
        {
            // Workaround
            // "System.NotSupportedException: No data is available for encoding 1252"
            // https://stackoverflow.com/questions/49215791/vs-code-c-sharp-system-notsupportedexception-no-data-is-available-for-encodin
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
        }

        public SpreadsheetRepository( string path, Encoding encoding = null )
        {
            Path = path ?? throw new ArgumentNullException( nameof( path ) );
        }

        public Workbook Load()
        {
            var result = new Workbook( Path );

            using( var stream = File.Open( Path, FileMode.Open, FileAccess.Read ) )
            using( var reader = ExcelReaderFactory.CreateReader( stream ) )
            {
                var dataSet = reader.AsDataSet();
                var book = dataSet.Tables;

                foreach( SourceSheet s in book )
                {
                    // Ignore sheet
                    if( s.TableName == SpreadsheetConstants.LIST_DEFINITION_SHEETNAME )
                    {
                        continue;
                    }

                    Worksheet worksheet = ParseWorksheet( s );
                    result.Worksheets.Add( worksheet );
                }
            }

            return result;
        }

        private Worksheet ParseWorksheet( SourceSheet sheet )
        {
            SourceRows rows = sheet.Rows;

            Worksheet worksheet = new Worksheet();
            for( int rowIndex = SpreadsheetConstants.START_ROW_INDEX; rowIndex < rows.Count; rowIndex++ )
            {
                var context = new CellContext()
                {
                    Sheet    = sheet,
                    Row      = rows[ rowIndex ],
                    RowIndex = rowIndex
                };
                var row = ParseRow( context );
                worksheet.Rows.Add( row );
            }

            return worksheet;
        }

        private Row ParseRow( CellContext context )
        {
            Row row;

            var articulationCellGroup = ParseArticulation( context );

            row = new Row(
                articulationCellGroup.NameCell,
                articulationCellGroup.TypeCell,
                articulationCellGroup.ColorIndexCell,
                articulationCellGroup.GroupIndexCell
            );

            return row;
        }

        private ArticulationCellGroup ParseArticulation( CellContext context )
        {
            var articulationCellGroup = new ArticulationCellGroup();

            var sourceSheet = context.Sheet;
            var sourceRow = context.Row;
            var rowIndex = context.RowIndex;

            string cellValue;

            ParseSheet( context, SpreadsheetConstants.COLUMN_NAME, out cellValue );
            articulationCellGroup.NameCell = new ArticulationNameCell( cellValue );

            ParseSheet( context, SpreadsheetConstants.COLUMN_ARTICULATION_TYPE, out cellValue );
            articulationCellGroup.TypeCell = ArticulationTypeCell.Parse( cellValue );

            ParseSheet( context, SpreadsheetConstants.COLUMN_COLOR, out cellValue );
            articulationCellGroup.ColorIndexCell = new ColorIndexCell( int.Parse( cellValue ) );

            return articulationCellGroup;
        }

        private List<Row.MidiNote> ParseMidiNotes( CellContext context )
        {
            //----------------------------------------------------------------------
            // Append MIDI Notes
            // * Multiple MIDI Note Supported
            // * Column name format:
            // MIDI Note1 ... MIDI Note1+n
            // Velocity1 ... Velocity1+n
            //----------------------------------------------------------------------
            var notes = new List<Row.MidiNote>();

            for( int i = 1; i < int.MaxValue; i++ )
            {
                if( !TryParseSheet( context, SpreadsheetConstants.COLUMN_MIDI_NOTE + i, out var noteNumberCell ) )
                {
                    break;
                }

                ParseSheet( context, SpreadsheetConstants.COLUMN_MIDI_VELOCITY + i, out var velocityCell );

                if( !int.TryParse( velocityCell, out var velocityValue ) )
                {
                    break;
                }

                var obj = new Row.MidiNote()
                {
                    Note = new MidiNoteNumberCell( noteNumberCell ),
                    Velocity =  new MidiNoteVelocityCell( velocityValue )
                };

                notes.Add( obj );
            }

            return notes;
        }

        private static void ParseSheet( CellContext context, string columnName, out string result )
        {
            if( !TryParseSheet( context.Sheet, context.RowIndex, columnName, out result ) )
            {
                throw new InvalidCellValueException( context.RowIndex, columnName );
            }
        }

        private static bool TryParseSheet( CellContext context, string columnName, out string result )
        {
            return TryParseSheet( context.Sheet, context.RowIndex, columnName, out result );
        }

        private static bool TryParseSheet( SourceSheet sheet, int rowIndex, string columnName, out string result )
        {
            var rows       = sheet.Rows;
            var columns = sheet.Columns;

            int i = 0;
            result = null;

            foreach( var name in rows[ SpreadsheetConstants.HEADER_ROW_INDEX ].ItemArray )
            {
                if( name != null && name.ToString() == columnName )
                {
                    var cell = rows[ rowIndex ].ItemArray[ i ];

                    if( cell == null )
                    {
                        return false;
                    }

                    result = cell.ToString();

                    return true;
                }
                i++;
            }
            return false;
        }


    }
}