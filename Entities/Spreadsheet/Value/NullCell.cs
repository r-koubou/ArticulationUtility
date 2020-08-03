using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class NullCell : ICell
    {
        public static ICell Instance { get; } = new NullCell();

        public string Value { get; } = string.Empty;

        private NullCell()
        {
        }

        public void Accept( ICellVisitor visitor )
        {
            visitor.Visit( this );
        }

        public bool Equals( [AllowNull] ICell other )
        {
            return other != null && Instance == other;
        }
    }
}