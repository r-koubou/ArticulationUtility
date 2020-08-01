using System;
using System.Collections.Generic;
using System.Linq;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet
{

    public class Row : IRow
    {
        private SortedDictionary<int, ICell> Columns { get; } = new SortedDictionary<int, ICell>();

        public int ColumnCount
        {
            get
            {
                if( Columns.Count == 0 )
                {
                    return 0;
                }

                return Columns.Last().Key;
            }
        }

        public ICell this[ int columnIndex ]
        {
            get
            {
                if( Columns.ContainsKey( columnIndex ) )
                {
                    return Columns[ columnIndex ];
                }

                return NullCell.Instance;
            }
            set => Columns[ columnIndex ] = value;
        }
    }
}