using System.Data;

namespace ArticulationUtility.Gateways.Spreadsheet
{
    public class CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}