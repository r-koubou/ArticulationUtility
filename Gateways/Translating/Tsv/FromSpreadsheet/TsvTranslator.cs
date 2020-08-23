using System.Collections.Generic;
using System.Text;

using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.Entities.Tsv.Value;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.Gateways.Translating.Tsv.FromSpreadsheet
{
    public class TsvTranslator : ITsvTranslator<Worksheet>
    {
        public List<TsvData> Translate( Worksheet worksheet )
        {
            var result = new List<TsvData>();

            var lines = ToTsvTextList( worksheet );
            var tsvLines = new List<TsvLine>();

            foreach( var line in lines )
            {
                tsvLines.Add( new TsvLine( line ) );
            }

            result.Add(
                new TsvData( tsvLines )
            );

            return result;
        }

        private IEnumerable<string> ToTsvTextList( Worksheet sheet )
        {
            var result = new List<string>();
            var buffer = new StringBuilder( 128 );

            foreach( var row in sheet.Rows )
            {
                buffer.Clear();

                buffer.Append( row.ArticulationName.Value ).Append( TsvLine.Separator );
                buffer.Append( row.ColorIndex.Value ).Append( TsvLine.Separator );
                buffer.Append( row.ArticulationType.Value ).Append( TsvLine.Separator );
                buffer.Append( row.GroupIndex.Value ).Append( TsvLine.Separator );

                AppendMidiNote( row, buffer );
                AppendMidiCc( row, buffer );
                AppendMidiPc( row, buffer );

                result.Add( buffer.ToString() );
            }
            return result;
        }

        private bool AppendSeparatorForEmptyList<T>( IReadOnlyList<T> list, StringBuilder buffer )
        {
            if( list.Count != 0 )
            {
                return false;
            }

            buffer.Append( TsvLine.Separator );
            return true;

        }

        private void AppendMidiNote( Row row, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( row.MidiNoteList, buffer ) )
            {
                return;
            }

            foreach( var midiNote in row.MidiNoteList )
            {
                buffer.Append( midiNote.Note.Value ).Append( TsvLine.Separator );
                buffer.Append( midiNote.Velocity.Value ).Append( TsvLine.Separator );
            }
        }

        private void AppendMidiCc( Row row, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( row.MidiControlChangeList, buffer ) )
            {
                return;
            }

            foreach( var midiCc in row.MidiControlChangeList )
            {
                buffer.Append( midiCc.CcNumber.Value ).Append( TsvLine.Separator );
                buffer.Append( midiCc.CcValue.Value ).Append( TsvLine.Separator );
            }
        }

        private void AppendMidiPc( Row row, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( row.MidiProgramChangeList, buffer ) )
            {
                return;
            }

            foreach( var midiPc in row.MidiProgramChangeList )
            {
                buffer.Append( midiPc.Channel.Value ).Append( TsvLine.Separator );
                buffer.Append( midiPc.Data.Value ).Append( TsvLine.Separator );
            }
        }

    }
}