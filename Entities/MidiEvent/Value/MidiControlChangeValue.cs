namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiControlChangeValue : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiControlChangeValue( int value )
            : base( value, MinValue, MaxValue )
        {}

        public override int GetHashCode() => 506422555 * Value;
    }
}