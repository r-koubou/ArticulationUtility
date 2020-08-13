using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Value
{
    public class OutputNameCell : StringCell
    {
        public static readonly OutputNameCell Empty = new OutputNameCell();

        private OutputNameCell() : base( string.Empty )
        {
        }

        public OutputNameCell( string name ) : base( name )
        {
            if( StringHelper.IsNullOrTrimEmpty( Value ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
        }
    }
}