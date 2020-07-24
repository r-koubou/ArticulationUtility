using System;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    public class Id : IEquatable<Id>
    {
        public string Value { get; }

        public Id()
        {
            var guid = Guid.NewGuid().ToString();
            var hex = guid.Split( '-' )[ 0 ];
            Value = ( Convert.ToInt32( hex, 16 ) & 0x7ffffff ).ToString();
        }

        public bool Equals( Id other )
        {
            if( other == null )
            {
                return false;
            }

            return Value == other.Value;
        }
    }
}