namespace ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap
{
    public class InvalidCellValueException : System.Exception
    {
        public InvalidCellValueException()
        {}

        public InvalidCellValueException( int rowIndex, string columnLabel )
            : base( $"Row:{rowIndex}, Column:{columnLabel} is invalid." )
        {
        }

        public InvalidCellValueException( string message ) : base( message )
        {
        }
    }
}