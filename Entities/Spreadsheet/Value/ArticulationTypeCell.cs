using System;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class ArticulationTypeCell : IEquatable<ArticulationTypeCell>
    {
        public static readonly ArticulationTypeCell Direction = new ArticulationTypeCell( "Direction" );
        public static readonly ArticulationTypeCell Attribute = new ArticulationTypeCell( "Attribute" );
        public string Value { get; }

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