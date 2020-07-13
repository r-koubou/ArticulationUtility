using System.Collections.Generic;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class WorkBook
    {
        public string Path { get; } = string.Empty;
        public readonly List<Worksheet> Worksheets = new List<Worksheet>();
    }
}