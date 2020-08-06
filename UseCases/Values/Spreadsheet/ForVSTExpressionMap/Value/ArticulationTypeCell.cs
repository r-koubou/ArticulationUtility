using System;
using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class ArticulationTypeCell : IEquatable<ArticulationTypeCell>
    {
        public static readonly ArticulationTypeCell Direction = new ArticulationTypeCell( "Direction" );
        public static readonly ArticulationTypeCell Attribute = new ArticulationTypeCell( "Attribute" );
        public static readonly ArticulationTypeCell Default = Direction;
        public string Value { get; }

        public static ArticulationTypeCell Parse( string value )
        {
            if( value == null )
            {
                throw new ArgumentNullException( nameof( value ) );
            }

            if( value == Direction.Value )
            {
                return Direction;
            }

            if( value == Attribute.Value )
            {
                return Attribute;
            }

            throw new ArgumentException( nameof( value ) );
        }

        private ArticulationTypeCell( string name )
        {
            Value = name;
        }

        public bool Equals( [AllowNull] ArticulationTypeCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;

    }
}