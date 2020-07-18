using System.Collections.Generic;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Worksheet
    {
        public string Name { get; }
        public readonly List<Row> Rows = new List<Row>();

        public Worksheet( string name = null )
        {
            Name = name ?? string.Empty;
        }
    }
}