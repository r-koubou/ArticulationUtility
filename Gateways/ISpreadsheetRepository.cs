using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;

namespace ArticulationUtility.Gateways
{
    public interface ISpreadsheetRepository
    {
        public IReadOnlyList<SpreadsheetRow> Load();
        public void Save( IReadOnlyList<SpreadsheetRow> rows );
    }
}