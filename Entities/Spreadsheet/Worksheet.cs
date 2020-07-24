using System;
using System.Collections.Generic;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Worksheet
    {
        public string SheetName { get; set; } = string.Empty;
        public SortedDictionary<int, Row> Rows { get; } = new SortedDictionary<int, Row>();

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

        public Row this[ int rowIndex ]
        {
            get
            {
                if( Rows.ContainsKey( rowIndex ) )
                {
                    return Rows[ rowIndex ];
                }

                return null;
            }
            set => Rows[ rowIndex ] = value;
        }

        public ICell this[ int rowIndex, int columnIndex ]
        {
            get
            {
                if( Rows.ContainsKey( rowIndex ) )
                {
                    return Rows[ rowIndex ].Columns[ columnIndex ];
                }
                return null;
            }
            set => Rows[ rowIndex ].Columns[ columnIndex ] = value;
        }
    }
}