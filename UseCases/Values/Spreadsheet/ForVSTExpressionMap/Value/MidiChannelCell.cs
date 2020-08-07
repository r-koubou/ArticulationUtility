using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Entities.Spreadsheet.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class MidiChannelCell : IntegerCell
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x0F;

        public MidiChannelCell( int velocity ) : base( velocity )
        {
            RangeValidateHelper.ValidateIntRange( Value, MinValue, MaxValue );
        }
    }
}