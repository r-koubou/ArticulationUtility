using ArticulationUtility.Gateways.Common;

namespace ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap
{
    public interface ISpreadsheetRepository<T> : IDataLoader<T>
    {
        public string LoadPath { get; set; }
    }
}