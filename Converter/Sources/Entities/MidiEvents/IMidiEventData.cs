namespace Spreadsheet2Expressionmap.Converter.Entities.MidiEvents
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
    }
}