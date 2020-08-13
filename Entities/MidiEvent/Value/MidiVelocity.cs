namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiVelocity : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiVelocity( int value )
            : base( value, MinValue, MaxValue )
        {}

        public override int GetHashCode() => 1691916126 * Value;
    }
}