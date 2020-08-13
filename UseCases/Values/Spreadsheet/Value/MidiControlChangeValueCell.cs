using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Value
{
    public class MidiControlChangeValueCell : IntegerCell
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiControlChangeValueCell( int ccValue ) : base( ccValue )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}