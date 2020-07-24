using System.Collections.Generic;
using System.Linq;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Row
    {
        public SortedDictionary<int, ICell> Columns { get; } = new SortedDictionary<int, ICell>();

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

                return null;
            }
            set => Columns[ columnIndex ] = value;
        }
    }
}