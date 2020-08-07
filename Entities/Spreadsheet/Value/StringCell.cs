using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class StringCell : GenericCell<string>
    {
        public StringCell( string value ) : base( value )
        {}

        public override bool Equals( [AllowNull] ICell obj )
        {
            if( obj?.Value == null )
            {
                return false;
            }

            if( obj.Value is string s )
            {
                return Value == s;
            }

            return false;
        }
    }
}