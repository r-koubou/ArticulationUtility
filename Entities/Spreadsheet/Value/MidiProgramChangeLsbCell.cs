using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class MidiProgramChangeLsbCell : IEquatable<MidiProgramChangeLsbCell>
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7f;

        public int Value { get; }

        public MidiProgramChangeLsbCell( int lsb )
        {
            RangeValidateHelper.ValidateIntRange( lsb, MinValue, MaxValue );
            Value = lsb;
        }

        public bool Equals( MidiProgramChangeLsbCell other )
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