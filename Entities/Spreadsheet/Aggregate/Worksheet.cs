using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet.Aggregate
{
    public class Worksheet
    {
        public string SheetName { get; set; } = string.Empty;
        public SortedDictionary<int, IRow> Rows { get; } = new SortedDictionary<int, IRow>();

        public int RowsCount => Rows.Count;

        public int MaxColumnCount
        {
            get
            {
                var max = 0;
                foreach( var row in Rows.Values )
                {
                    max = Math.Max( max, row.ColumnCount );
                }

                return max;
            }
        }

        public IRow this[ int rowIndex ]
        {
            get
            {
                if( Rows.ContainsKey( rowIndex ) )
                {
                    return Rows[ rowIndex ];
                }

                return NullRow.Instance;
            }
            set => Rows[ rowIndex ] = value;
        }

        public ICell this[ int rowIndex, int columnIndex ]
        {
            get
            {
                if( Rows.ContainsKey( rowIndex ) )
                {
                    return Rows[ rowIndex ][ columnIndex ];
                }
                return NullCell.Instance;
            }
            set => Rows[ rowIndex ][ columnIndex ] = value;
        }
    }
}