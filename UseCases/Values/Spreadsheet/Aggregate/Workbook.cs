using System;
using System.Collections.Generic;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate
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