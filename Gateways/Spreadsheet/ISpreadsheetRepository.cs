using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7.Aggregate;

namespace ArticulationUtility.Gateways.Spreadsheet
{
    public interface ISpreadsheetRepository : IDataLoader<Workbook>
    {
    }
}