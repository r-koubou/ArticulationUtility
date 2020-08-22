using System.Data;

namespace ArticulationUtility.FileAccessors.Spreadsheet
{
    internal struct CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}