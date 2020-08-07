using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class Cell : ICell
    {
        public object Value { get; }

        public Cell( object value )
        {
            Value = value;
        }

        public bool Equals( [AllowNull] ICell other )
        {
            return other != null && other.Value == Value;
        }
    }
}