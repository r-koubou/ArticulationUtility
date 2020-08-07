using System.Data;

namespace ArticulationUtility.FileAccessing.Spreadsheet
{
    public struct CellContext
    {
        public int RowIndex;
        public DataTable Sheet;
        public DataRow Row;
    }
}