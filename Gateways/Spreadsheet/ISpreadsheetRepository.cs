using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.Spreadsheet.Aggregate;

namespace ArticulationUtility.Gateways.Spreadsheet
{
    public interface ISpreadsheetRepository : IDataLoader<Workbook>
    {
    }
}