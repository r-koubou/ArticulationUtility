using System;

namespace ArticulationUtility.Utilities
{
    public static class EnumHelper
    {
        #region Parser
        // see also
        // https://qiita.com/masaru/items/a44dc30bfc18aac95015
        static public bool TryParse<TEnum>( string text, out TEnum target, TEnum defaultValue ) where TEnum : struct
        {
            return Enum.TryParse( text, out target ) && Enum.IsDefined( typeof( TEnum ), target );
        }

        static public TEnum Parse<TEnum>( string text, TEnum defaultValue ) where TEnum : struct
        {
            if( string.IsNullOrEmpty( text ) )
            {
                return defaultValue;
            }

            if( !TryParse( text, out TEnum target, defaultValue ) )
            {
                return defaultValue;
            }

            return target;
        }

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

        #region Converter
        public static bool TryFromInt<T>( int v, out T result ) where T : struct
        {
            result = default;
            try
            {
                result = (T)Enum.ToObject( typeof( T ), v );
                return true;
            }
            catch( Exception e )
            {
                return false;
            }
        }

        public static T FromInt<T>( int v ) where T : struct
        {
            return (T)Enum.ToObject( typeof( T ), v );
        }
        #endregion
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