using System.Data;

namespace ArticulationUtility.Gateways.Spreadsheet
{
    public struct CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}