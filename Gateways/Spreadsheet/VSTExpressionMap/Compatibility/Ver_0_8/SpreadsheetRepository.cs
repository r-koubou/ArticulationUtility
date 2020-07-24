using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Aggregate;
using ArticulationUtility.UseCases.Values.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8.Value;

using ExcelDataReader;

using SourceSheet   = System.Data.DataTable;
using SourceRows    = System.Data.DataRowCollection;

namespace ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_8
{
    public class SpreadsheetRepository : ISpreadsheetRepository<Workbook>
    {
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
                    if( s.TableName == CommonSheetConstants.DefinitionSheetName )
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

            Worksheet worksheet = new Worksheet( sheet.TableName );
            for( int rowIndex = SpreadsheetConstants.StartRowIndex; rowIndex < rows.Count; rowIndex++ )
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

            var outputName = rows[ SpreadsheetConstants.RowOutputIndex ]
                            .ItemArray[ SpreadsheetConstants.ColumnOutputNameIndex ].ToString();

            worksheet.OutputNameCell = new OutputNameCell( outputName );

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

            row.MidiNoteList.AddRange( ParseMidiNotes( context ) );
            row.MidiControlChangeList.AddRange( ParseMidiControlChanges( context ) );
            row.MidiProgramChangeList.AddRange( ParseMidiProgramChanges( context ) );

            return row;
        }

        private ArticulationCellGroup ParseArticulation( CellContext context )
        {
            var articulationCellGroup = new ArticulationCellGroup();

            ParseSheet( context, SpreadsheetConstants.ColumnArticulationName, out var cellValue );
            articulationCellGroup.NameCell = new ArticulationNameCell( cellValue );

            ParseSheet( context, SpreadsheetConstants.ColumnArticulationType, out cellValue );
            articulationCellGroup.TypeCell = ArticulationTypeCell.Parse( cellValue );

            ParseSheet( context, SpreadsheetConstants.ColumnColor, out cellValue );
            articulationCellGroup.ColorIndexCell = new ColorIndexCell( int.Parse( cellValue ) );

            return articulationCellGroup;
        }

        private List<Row.MidiNote> ParseMidiNotes( CellContext context )
        {
            //----------------------------------------------------------------------
            // MIDI Notes
            // * Multiple MIDI Note Supported
            // * Column name format:
            // MIDI Note1 ... MIDI Note1+n
            // Velocity1 ... Velocity1+n
            //----------------------------------------------------------------------
            var notes = new List<Row.MidiNote>();

            for( int i = 1; i < int.MaxValue; i++ )
            {
                if( !TryParseSheet( context, SpreadsheetConstants.ColumnMidiNote + i, out var noteNumberCell ) )
                {
                    break;
                }

                ParseSheet( context, SpreadsheetConstants.ColumnMidiVelocity + i, out var velocityCell );

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

        private List<Row.MidiControlChange> ParseMidiControlChanges( CellContext context )
        {
            //----------------------------------------------------------------------
            // MIDI CC
            // * Multiple MIDI CC Supported
            // * Column name format:
            //   CC No1 ... CC No1+n
            //   CC Value1 ... CC Value1+n
            //----------------------------------------------------------------------
            var controlChanges = new List<Row.MidiControlChange>();

            for( int i = 1; i < int.MaxValue; i++ )
            {

                if( !TryParseSheet( context, SpreadsheetConstants.ColumnMidiCc + i, out var ccNumberCell ) )
                {
                    break;
                }
                if( !TryParseSheet( context, SpreadsheetConstants.ColumnMidiCcValue + i, out var ccValueCell ) )
                {
                    break;
                }

                var obj = new Row.MidiControlChange()
                {
                    CcNumber = new MidiControlChangeNumberCell( int.Parse( ccNumberCell ) ),
                    CcValue  = new MidiControlChangeValueCell( int.Parse( ccValueCell ) )
                };

                controlChanges.Add( obj );
            }

            return controlChanges;
        }

        private List<MidiProgramCell> ParseMidiProgramChanges( CellContext context )
        {
            //----------------------------------------------------------------------
            // Program (MIDI Program Change?)
            // * Multiple value Supported
            // * Column name format:
            //   Program1 ... Program1+n
            //----------------------------------------------------------------------
            var program = new List<MidiProgramCell>();

            for( int i = 1; i < int.MaxValue; i++ )
            {

                if( !TryParseSheet( context, SpreadsheetConstants.ColumnMidiPcLsb + i, out var pcLsbCell ) )
                {
                    break;
                }

                var obj = new MidiProgramCell( int.Parse( pcLsbCell ) );
                program.Add( obj );
            }

            return program;
        }

        #region Core Parsers

        private static void ParseSheet( CellContext context, string columnName, out string result )
        {
            if( !TryParseSheet( context.Sheet, context.RowIndex, columnName, out result ) )
            {
                throw new InvalidCellValueException( context.RowIndex, columnName );
            }
        }

        private static void ParseSheet( SourceSheet sheet, int rowIndex, string columnName, out string result )
        {
            if( !TryParseSheet( sheet, rowIndex, columnName, out result ) )
            {
                throw new InvalidCellValueException( rowIndex, columnName );
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

            foreach( var name in rows[ SpreadsheetConstants.HeaderRowIndex ].ItemArray )
            {
                if( name != null && name.ToString() == columnName )
                {
                    var cell = rows[ rowIndex ].ItemArray[ i ];

                    if( cell == null )
                    {
                        return false;
                    }

                    result = cell.ToString();

                    return result != null &&
                           !string.IsNullOrEmpty( result.Trim() );
                }
                i++;
            }
            return false;
        }

        #endregion

    }
}