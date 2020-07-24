namespace ArticulationUtility.Entities.Spreadsheet
{
    public interface ICell
    {
        public string Value { get; set; }
        public void Accept( ICellVisitor visitor ) => visitor.Visit( this );
    }
}