using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class Cell : ICell
    {
        public string Value { get; }

        public Cell( string value )
        {
            Value = value;
        }

        public void Accept( ICellVisitor visitor )
        {
            visitor.Visit( this );
        }

        public bool Equals( [AllowNull] ICell other )
        {
            return other != null && other.Value == Value;
        }
    }
}