namespace ArticulationUtility.Entities.Spreadsheet
{
    public interface ICellVisitor
    {
        public void Visit( ICell cell );
    }
}