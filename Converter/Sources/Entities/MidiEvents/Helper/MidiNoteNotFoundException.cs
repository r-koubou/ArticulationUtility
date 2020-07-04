using System;

namespace VSTExpressionMap.Core.Entities.MidiEvents.Helper
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