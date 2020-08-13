namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiNoteNumber :MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x7F;

        public MidiNoteNumber( int value )
            : base( value, MinValue, MaxValue )
        {}

        public override int GetHashCode() => 316587340 * Value;
    }
}