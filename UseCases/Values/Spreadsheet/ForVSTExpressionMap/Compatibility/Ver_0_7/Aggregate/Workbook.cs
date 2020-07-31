using System;
using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Aggregate
{
    public class Workbook
    {
        public string Path { get; }
        public readonly List<Worksheet> Worksheets = new List<Worksheet>();

        public Workbook( string path )
        {
            Path = path ?? throw new ArgumentNullException( nameof( path ) );
        }
    }
}