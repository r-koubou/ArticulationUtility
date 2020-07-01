using System;

namespace Spreadsheet2Expressionmap.Converter.Entity.Helper
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