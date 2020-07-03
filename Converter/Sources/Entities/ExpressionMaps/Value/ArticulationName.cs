using System;

namespace Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps.Value
{
    /// <summary>
    /// An Articulation name
    /// </summary>
    public class ArticulationName : IEquatable<ArticulationName>
    {
        private string Name { get; }

        public ArticulationName( string name )
        {
            if( string.IsNullOrEmpty( name ) || name.Trim().Length == 0 )
            {
                throw new System.ArgumentException( $"{nameof(name)} is null or empty" );
            }
            Name = name;
        }

        public bool Equals( ArticulationName other )
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
