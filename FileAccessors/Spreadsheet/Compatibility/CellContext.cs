using System.Data;

namespace ArticulationUtility.FileAccessors.Spreadsheet.Compatibility
{
    internal struct CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}