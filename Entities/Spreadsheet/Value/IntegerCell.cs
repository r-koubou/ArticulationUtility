namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class IntegerCell : Cell
    {
        public int IntValue { get; }
        public IntegerCell( int value ) : base( value )
        {
            IntValue = value;
        }
    }
}