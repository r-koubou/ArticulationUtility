namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Cell : ICell
    {
        public string Value { get; set; }

        public void Accept( ICellVisitor visitor )
        {
            visitor.Visit( this );
        }
    }
}