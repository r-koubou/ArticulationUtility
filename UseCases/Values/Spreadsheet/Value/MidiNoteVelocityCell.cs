using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.Value
{
    public class MidiNoteVelocityCell : IntegerCell
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiNoteVelocityCell( int velocity ) : base( velocity )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}