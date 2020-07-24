using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    /// <summary>
    /// An Articulation name
    /// </summary>
    public class ArticulationName : IEquatable<ArticulationName>
    {
        public string Value { get; }

        public ArticulationName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
            Value = name;
        }

        public bool Equals( ArticulationName other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value;

    }
}
