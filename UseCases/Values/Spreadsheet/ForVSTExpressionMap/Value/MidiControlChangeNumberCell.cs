using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class MidiControlChangeNumberCell : IntegerCell
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiControlChangeNumberCell( int ccNumber ) : base( ccNumber )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}