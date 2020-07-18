using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Worksheet
    {
        public string Name { get; }
        public OutputNameCell OutputNameCell { get; set; }

        public readonly List<Row> Rows = new List<Row>();

        public Worksheet( string name )
        {
            Name = name ?? throw new ArgumentNullException( nameof( name ) );
        }
    }
}