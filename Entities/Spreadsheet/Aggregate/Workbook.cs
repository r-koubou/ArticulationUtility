using System.Collections.Generic;

namespace ArticulationUtility.Entities.Spreadsheet.Aggregate
{
    public class Workbook
    {
        public List<Worksheet> Worksheets { get; } = new List<Worksheet>();
    }
}