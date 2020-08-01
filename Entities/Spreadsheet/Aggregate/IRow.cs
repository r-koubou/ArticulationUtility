using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet.Aggregate
{
    public interface IRow
    {
        public int ColumnCount { get; }

        public ICell this[ int columnIndex ] { get; set; }
    }
    public class NullRow : IRow
    {
        public static IRow Instance { get; } = new NullRow();

        private NullRow()
        {
        }

        public int ColumnCount { get; } = 0;

        public ICell this[ int columnIndex ]
        {
            get => NullCell.Instance;
            set {}
        }
    }

}