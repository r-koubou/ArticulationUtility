using System;

using ArticulationUtility.Entities.Spreadsheet.Value;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class ArticulationTypeCell : StringCell
    {
        public static readonly ArticulationTypeCell Direction = new ArticulationTypeCell( "Direction" );
        public static readonly ArticulationTypeCell Attribute = new ArticulationTypeCell( "Attribute" );
        public static readonly ArticulationTypeCell Default = Direction;

        public static ArticulationTypeCell Parse( string value )
        {
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

        private ArticulationTypeCell( string name ) : base( name )
        {
        }
    }
}