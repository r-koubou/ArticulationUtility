using System;
using System.Data;
using System.IO;
using System.Text;

using ArticulationUtility.FileAccessors.Spreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.Gateways.Translating.Tsv;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;
using ArticulationUtility.Utilities;

using ExcelDataReader;

using Repository_Version_0_7 = ArticulationUtility.FileAccessors.Spreadsheet.Compatibility.Ver_0_7.SpreadsheetFileRepository;
using Repository_Version_0_8 = ArticulationUtility.FileAccessors.Spreadsheet.Compatibility.Ver_0_8.SpreadsheetFileRepository;

namespace ArticulationUtility.FileAccessors.Spreadsheet.Compatibility
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

        public static ISpreadsheetFileRepository CreateRepository( SpreadsheetVersion version )
        {
            switch( version )
            {
                case SpreadsheetVersion.Ver_0_7:
                    return new Repository_Version_0_7();
                case SpreadsheetVersion.Ver_0_8:
                    return new Repository_Version_0_8();
                default:
                    throw new ArgumentException( $"Spreadsheet Repository for `{version}` not found");
            }
        }

        public static SpreadsheetVersion DetectVersion( string spreadsheetFilePath )
        {
            using var stream = File.Open( spreadsheetFilePath, FileMode.Open, FileAccess.Read );
            using var reader = ExcelReaderFactory.CreateReader( stream );

            var dataSet = reader.AsDataSet();
            var book = dataSet.Tables;

            try
            {
                // Search version value A1 in "DO NOT EDIT" sheet.
                foreach( DataTable? sheet in book )
                {
                    if( sheet == null )
                    {
                        throw new ObjectIsNullException();
                    }

                    if( sheet.TableName != CommonSheetConstants.DefinitionSheetName )
                    {
                        continue;
                    }

                    var value = sheet.Rows[ 0 ][ 0 ].ToString();

                    switch( value )
                    {
                        case "MIDI Notes":
                            return SpreadsheetVersion.Ver_0_7;
                        case "Version 0.8":
                            return SpreadsheetVersion.Ver_0_8;
                    }
                }

                return SpreadsheetVersion.Unknown;
            }
            catch
            {
                return SpreadsheetVersion.Unknown;
            }
        }

        public static ISpreadsheetFileRepository DetectRepository( string spreadsheetFilePath )
        {
            var version = DetectVersion( spreadsheetFilePath );
            return CreateRepository( version );
        }

    }
}