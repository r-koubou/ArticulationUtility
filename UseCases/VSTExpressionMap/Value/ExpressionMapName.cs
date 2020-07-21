using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.VSTExpressionMap.Value
{
    /// <summary>
    /// A ExpressionMap name
    /// </summary>
    public class ExpressionMapName : IEquatable<ExpressionMapName>
    {
        private string Name { get; }

        public ExpressionMapName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
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
