namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class StringCell : Cell
    {
        public string StringValue { get; }
        public StringCell( string value ) : base( value )
        {
            StringValue = value;
        }
    }
}