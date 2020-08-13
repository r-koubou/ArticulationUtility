using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Value
{
    public class ArticulationNameCell : StringCell
    {
        public static readonly ArticulationNameCell Empty
            = new ArticulationNameCell( CellConstants.NotAvailableCellValue );

        public ArticulationNameCell( string name ) : base( name )
        {
            if( StringHelper.IsNullOrTrimEmpty( Value ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
        }
    }
}