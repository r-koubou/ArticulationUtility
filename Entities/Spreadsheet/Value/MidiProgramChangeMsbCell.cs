using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class MidiProgramChangeMsbCell : IEquatable<MidiProgramChangeMsbCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiProgramChangeMsbCell( int lsb )
        {
            RangeValidateHelper.ValidateIntRange( lsb, MinValue, MaxValue );
            Value = lsb;
        }

        public bool Equals( MidiProgramChangeMsbCell other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}