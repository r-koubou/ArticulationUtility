using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.FileAccessors.Spreadsheet.Compatibility
{
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    public enum SpreadsheetVersion
    {
        Unknown,
        Ver_0_7,
        Ver_0_8,

        Latest = Ver_0_8
    }
}