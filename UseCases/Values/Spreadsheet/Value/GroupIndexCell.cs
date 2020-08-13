using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Value
{
    public class GroupIndexCell : IntegerCell
    {
        public const int MinValue = 0;
        public const int MaxValue = 3;
        public static readonly GroupIndexCell Default = new GroupIndexCell( MinValue );

        public GroupIndexCell( int index ) : base( index )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}