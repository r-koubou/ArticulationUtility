namespace ArticulationUtility.Domain.Helper
{
    public static class StringHelper
    {
        public static bool IsNullOrTrimEmpty(  string text )
        {
            return string.IsNullOrEmpty( text ) || text.Trim().Length == 0;
        }
    }
}