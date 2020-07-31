namespace ArticulationUtility.Utilities
{
    public class InvalidNameException : System.Exception
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException( string variableName ) : base( $"{variableName} is invalid (null or empty?)" )
        {
        }
    }
}