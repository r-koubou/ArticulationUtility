using System;

namespace VSTExpressionMapTools.Domain.VSTExpressionMap.Value
{
    public class Uuid : IEquatable<Uuid>
    {
        public string Value { get; }

        private Uuid()
        {
            Value = System.Guid.NewGuid().ToString( "D" );
        }

        public static Uuid New()
            => new Uuid();

        public bool Equals( Uuid other )
        {
            if( other == null )
            {
                return false;
            }

            return Value == other.Value;
        }
    }
}