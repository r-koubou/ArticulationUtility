namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class NullCell : ICell
    {
        private static readonly ICell instance = new NullCell();
        public static ICell Instance => instance;

        public string Value { get; } = string.Empty;

        private NullCell()
        {
        }

        public void Accept( ICellVisitor visitor )
        {
            visitor.Visit( this );
        }

        public bool Equals( ICell other ) => Instance == other;
    }
}