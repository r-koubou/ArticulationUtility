namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiProgramChangeNumber : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x0F;

        public MidiProgramChangeNumber( int value )
            : base( value, MinValue, MaxValue )
        {}

        public override int GetHashCode() => 1757310380 * Value;
    }
}