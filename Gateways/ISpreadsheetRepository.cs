using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;

namespace ArticulationUtility.Gateways
{
    public interface ISpreadsheetRepository
    {
        public IReadOnlyList<Row> Load();
        public void Save( IReadOnlyList<Row> rows );
    }
}