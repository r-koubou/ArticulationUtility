using System;

namespace ArticulationUtility.Domain.VSTExpressionMap.Value
{
    /// <summary>
    /// A ExpressionMap name
    /// </summary>
    public class ExpressionMapName : IEquatable<ExpressionMapName>
    {
        private string Name { get; }

        public ExpressionMapName( string name )
        {
            if( string.IsNullOrEmpty( name ) || name.Trim().Length == 0 )
            {
                throw new System.ArgumentException( $"{nameof(name)} is null or empty" );
            }
            Name = name;
        }

        public bool Equals( ExpressionMapName other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Name == Name;
        }

        public override string ToString() => Name;
    }
}
