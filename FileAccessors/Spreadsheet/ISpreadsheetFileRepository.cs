using ArticulationUtility.Gateways;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.FileAccessors.Spreadsheet
{
    public interface ISpreadsheetFileRepository : IFileRepository<Workbook>
    {}
}