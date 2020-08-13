namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiControlChangeNumber : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiControlChangeNumber( int value )
            : base( value, MinValue, MaxValue )
        {}

        public override int GetHashCode() => 1700714998 * Value;
    }
}