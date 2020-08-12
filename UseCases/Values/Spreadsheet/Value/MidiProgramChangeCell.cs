using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class MidiProgramChangeCell : IntegerCell
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiProgramChangeCell( int value ) : base( value )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}