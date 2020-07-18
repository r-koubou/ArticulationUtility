using System;
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
        public string InputFilePath { get; }

        public SpreadsheetRepository( string inputFilePath, Encoding encoding = null )
        {
            InputFilePath = inputFilePath ?? throw new ArgumentNullException( nameof( inputFilePath ) );
        }

        public Workbook Load()
        {
            var result = new Workbook( InputFilePath );

            // Workaround
            // "System.NotSupportedException: No data is available for encoding 1252"
            // https://stackoverflow.com/questions/49215791/vs-code-c-sharp-system-notsupportedexception-no-data-is-available-for-encodin
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

            using( var stream = File.Open( InputFilePath, FileMode.Open, FileAccess.Read ) )
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
                var row = ParseRow( sheet, rows[ rowIndex ], rowIndex );
                worksheet.Rows.Add( row );
            }

            return worksheet;
        }

        private Row ParseRow( SourceSheet sourceSheet, SourceRow sourceRow, int rowIndex )
        {
            Row result;
            ArticulationNameCell nameCell;
            ArticulationTypeCell typeCell;
            ColorIndexCell colorIndexCell;

            string cellValue;

            ParseSheet( sourceSheet, rowIndex, SpreadsheetConstants.COLUMN_NAME, out cellValue );
            nameCell = new ArticulationNameCell( cellValue );

            ParseSheet( sourceSheet, rowIndex, SpreadsheetConstants.COLUMN_ARTICULATION_TYPE, out cellValue );
            typeCell = ArticulationTypeCell.Parse( cellValue );

            ParseSheet( sourceSheet, rowIndex, SpreadsheetConstants.COLUMN_COLOR, out cellValue );
            colorIndexCell = new ColorIndexCell( int.Parse( cellValue ) );

            result = new Row( nameCell, typeCell, colorIndexCell);

            return result;
        }

        private static void ParseSheet( SourceSheet sheet, int rowIndex, string columnName, out string result )
        {
            if( !TryParseSheet( sheet, rowIndex, columnName, out result ) )
            {
                throw new InvalidCellValueException( rowIndex, columnName );
            }
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