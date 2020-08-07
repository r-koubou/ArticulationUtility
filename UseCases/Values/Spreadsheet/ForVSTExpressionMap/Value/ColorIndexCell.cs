using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class ColorIndexCell : IntegerCell
    {
        public const int MinValue = 0;
        public const int MaxValue = 255;
        public static readonly ColorIndexCell Default = new ColorIndexCell( MinValue );

        public ColorIndexCell( int index ) : base( index )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}