namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiLeastSignificantByte : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiLeastSignificantByte( int value )
            : base( value, MinValue, MaxValue )
        {}
    }
}