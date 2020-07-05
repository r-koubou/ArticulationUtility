using System;

namespace VSTExpressionMapTools.Domain.MidiEvents.Helper
{
    public class MidiNoteNotFoundException : Exception
    {
        public MidiNoteNotFoundException()
        {
        }

        public MidiNoteNotFoundException( string message ) : base( message )
        {
        }
    }
}