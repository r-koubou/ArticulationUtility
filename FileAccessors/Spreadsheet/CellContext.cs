using System.Data;

namespace ArticulationUtility.FileAccessors.Spreadsheet
{
    public struct CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}