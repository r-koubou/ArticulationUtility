using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public interface IRow
    {
        public int ColumnCount { get; }

        public ICell this[ int columnIndex ] { get; set; }
    }
    public class NullRow : IRow
    {
        private static readonly IRow instance = new Row();
        public static IRow Instance => instance;

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