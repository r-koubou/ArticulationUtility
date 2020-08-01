namespace ArticulationUtility.Utilities
{
    public class ObjectIsNullException : System.Exception
    {
        public ObjectIsNullException() : base( "object is null" )
        {}

        public ObjectIsNullException( string message ) : base( message )
        {}
    }
}