using System;
using System.Collections.Generic;

using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Aggregate
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