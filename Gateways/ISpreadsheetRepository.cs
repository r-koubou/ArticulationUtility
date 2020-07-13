using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;

namespace ArticulationUtility.Gateways
{
    public interface ISpreadsheetRepository :
        IDataLoader<Workbook>,
        IDataSaver<Workbook>
    {
    }
}