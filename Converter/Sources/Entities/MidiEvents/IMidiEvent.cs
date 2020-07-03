namespace Spreadsheet2Expressionmap.Converter.Entities.MidiEvents
{
    /// <summary>
    /// MIDI event aggregation that makes up the sound slot.
    /// Status bytes are not defined because they are not used.
    /// </summary>
    public interface IMidiEvent<out TDataByte1, out TDataByte2>
        where TDataByte1 : IMidiEventData
        where TDataByte2 : IMidiEventData
    {
        /// <summary>
        /// MIDI event: 1st data byte
        /// </summary>
        public  TDataByte1 DataByte1 { get; }
        /// <summary>
        /// MIDI event: 2nd data byte
        /// </summary>
        public  TDataByte2 DataByte2 { get; }

    }
}