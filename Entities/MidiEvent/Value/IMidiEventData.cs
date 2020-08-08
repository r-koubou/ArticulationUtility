namespace ArticulationUtility.Entities.MidiEvent.Value
{
    /// <summary>
    /// An interface for MIDI Event data byte
    /// </summary>
    public interface IMidiEventData
    {
        /// <summary>
        /// MIDI event data values presented as integer values.
        /// </summary>
        public int Value { get; }

        public class Zero : IMidiEventData
        {
            private static readonly IMidiEventData instance = new Zero();
            public static IMidiEventData Instance => instance;

            private Zero()
            {}

            public int Value { get; } = 0;
        }
    }
}