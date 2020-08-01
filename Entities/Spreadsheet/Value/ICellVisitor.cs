namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public interface ICellVisitor
    {
        public void Visit( ICell cell );
    }
}