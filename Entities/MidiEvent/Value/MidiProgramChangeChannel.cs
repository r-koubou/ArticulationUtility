namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public class MidiProgramChangeChannel : MidiEventData
    {
        public const int MinValue = 0x00;
        public const int MaxValue = 0x0F;

        public MidiProgramChangeChannel( int value )
            : base( value, MinValue, MaxValue )
        {}
    }
}