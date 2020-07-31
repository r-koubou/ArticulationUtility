using System;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class ArticulationTypeCell : IEquatable<ArticulationTypeCell>
    {
        public static readonly ArticulationTypeCell Direction = new ArticulationTypeCell( "Direction" );
        public static readonly ArticulationTypeCell Attribute = new ArticulationTypeCell( "Attribute" );
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

        public bool Equals( ArticulationTypeCell other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();

    }
}