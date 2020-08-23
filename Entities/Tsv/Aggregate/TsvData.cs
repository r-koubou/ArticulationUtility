using System.Collections.Generic;

using ArticulationUtility.Entities.Tsv.Value;

namespace ArticulationUtility.Entities.Tsv.Aggregate
{
    public class TsvData
    {
        public IReadOnlyList<TsvLine> Rows { get; }

        public TsvData( IReadOnlyList<TsvLine> rows )
        {
            Rows = rows;
        }
    }
}