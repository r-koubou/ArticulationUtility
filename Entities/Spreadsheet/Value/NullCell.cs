using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class NullCell : ICell
    {
        public static ICell Instance { get; } = new NullCell();

        public object Value { get; } = string.Empty;

        private NullCell()
        {
        }

        public bool Equals( [AllowNull] ICell other )
        {
            return other != null && Instance == other;
        }
    }
}