using System;

namespace ArticulationUtility.Utilities
{
    public static class EnumHelper
    {
        #region Parser
        // see also
        // https://qiita.com/masaru/items/a44dc30bfc18aac95015
        static public bool TryParse<TEnum>( string text, out TEnum target ) where TEnum : struct
        {
            return Enum.TryParse( text, out target ) && Enum.IsDefined( typeof( TEnum ), target );
        }

        static public TEnum Parse<TEnum>( string text ) where TEnum : struct
        {
            if( !TryParse( text, out TEnum target ) )
            {
                throw new EnumValueNotFoundException( text, typeof( TEnum ) );
            }

            return target;
        }
        #endregion Parser
    }

    public class EnumValueNotFoundException : Exception
    {
        public EnumValueNotFoundException()
        {}

        public EnumValueNotFoundException( string message ) : base( message )
        {}

        public EnumValueNotFoundException( string name, Type enumType ) :
            this( $"Enum value `{name}` does not exist in type({enumType})" )
        {}
    }
}