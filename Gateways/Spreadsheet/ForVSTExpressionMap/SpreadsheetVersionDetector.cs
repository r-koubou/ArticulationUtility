using System.Data;
using System.IO;
using System.Text;

using ExcelDataReader;

namespace ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap
{
    public static class SpreadsheetVersionDetector
    {
        static SpreadsheetVersionDetector()
        {
            // Workaround
            // "System.NotSupportedException: No data is available for encoding 1252"
            // https://stackoverflow.com/questions/49215791/vs-code-c-sharp-system-notsupportedexception-no-data-is-available-for-encodin
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
        }

        public static SpreadsheetVersion Detect( string spreadsheetFilePath )
        {
            using var stream = File.Open( spreadsheetFilePath, FileMode.Open, FileAccess.Read );
            using var reader = ExcelReaderFactory.CreateReader( stream );

            var dataSet = reader.AsDataSet();
            var book = dataSet.Tables;

            try
            {
                // Search version value A1 in "DO NOT EDIT" sheet.
                foreach( DataTable sheet in book )
                {
                    if( sheet.TableName == CommonSheetConstants.DefinitionSheetName )
                    {
                        var value = sheet.Rows[ 0 ][ 0 ].ToString();

                        if( value == "MIDI Notes" )
                        {
                            return SpreadsheetVersion.Ver_0_7;
                        }
                        if( value == "Version 0.8" )
                        {
                            return SpreadsheetVersion.Ver_0_8;
                        }
                    }
                }

                return SpreadsheetVersion.Unknown;
            }
            catch
            {
                return SpreadsheetVersion.Unknown;
            }
        }
    }
}