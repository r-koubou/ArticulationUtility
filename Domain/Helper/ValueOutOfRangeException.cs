namespace ArticulationUtility.Domain.Helper
{
    public sealed class ValueOutOfRangeException : System.Exception
    {
        public ValueOutOfRangeException( string name, int value, int minValue, int maxValue )
            : base( $"{nameof(name)} is {value}. Min={minValue}, Max={maxValue}" )
        {
        }

        public ValueOutOfRangeException( string name, int value )
            : base( $"{nameof(name)} is {value}." )
        {
        }

        public ValueOutOfRangeException( int value )
            : base( $"Value is {value}." )
        {
        }

    }
}