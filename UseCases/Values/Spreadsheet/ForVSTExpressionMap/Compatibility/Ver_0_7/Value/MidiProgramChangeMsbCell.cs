using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value
{
    public class MidiProgramChangeMsbCell : IEquatable<MidiProgramChangeMsbCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public int Value { get; }

        public MidiProgramChangeMsbCell( int lsb )
        {
            RangeValidateHelper.ValidateIntRange( lsb, MinValue, MaxValue );
            Value = lsb;
        }

        public bool Equals( MidiProgramChangeMsbCell other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}