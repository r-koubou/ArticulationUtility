namespace ArticulationUtility.Utilities
{
    public static class NotNullValidator
    {
        public static void Validate<T>( T? obj ) where T : class
        {
            if( obj == null )
            {
                throw new ObjectIsNullException();
            }
        }
    }
}