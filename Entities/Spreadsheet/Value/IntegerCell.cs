using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class IntegerCell : GenericCell<int>
    {
        public IntegerCell( int value ) : base( value )
        {}

        public override bool Equals( [AllowNull] ICell obj )
        {
            if( obj?.Value == null )
            {
                return false;
            }

            if( obj.Value is int i )
            {
                return Value == i;
            }

            return false;
        }
    }
}