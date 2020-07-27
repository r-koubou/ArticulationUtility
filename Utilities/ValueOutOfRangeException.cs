namespace ArticulationUtility.Utilities
{
    public sealed class ValueOutOfRangeException : System.Exception
    {
        public ValueOutOfRangeException( int value, int minValue, int maxValue )
            : base( $"Value is {value}. Min={minValue}, Max={maxValue}" )
        {
        }

        public ValueOutOfRangeException( int value )
            : base( $"Value is {value}." )
        {
        }

    }
}