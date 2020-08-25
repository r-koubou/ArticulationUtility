using System.Collections.Generic;
using System.Text;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.Entities.Tsv.Value;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;

namespace ArticulationUtility.Gateways.Translating.Tsv.FromVSTExpressionMap
{
    public class TsvTranslator : ITsvTranslator<ExpressionMap>
    {
        public List<TsvData> Translate( ExpressionMap expressionMap )
        {
            var result = new List<TsvData>();

            var lines = ToTsvTextList( expressionMap );
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

        private IEnumerable<string> ToTsvTextList( ExpressionMap expressionMap )
        {
            var result = new List<string>();
            var buffer = new StringBuilder( 128 );

            foreach( var slot in expressionMap.SoundSlots )
            {
                buffer.Clear();

                var i = 0;
                foreach( var id in slot.ReferenceArticulationIds )
                {
                    var articulation = expressionMap.Articulations[ id ];
                    buffer.Append( slot.Name.Value ).Append( TsvLine.Separator );
                    buffer.Append( slot.ColorIndex.Value ).Append( TsvLine.Separator );
                    buffer.Append( articulation.Type.ToString() ).Append( TsvLine.Separator );
                    buffer.Append( articulation.Group.Value ).Append( TsvLine.Separator );

                    AppendMidiNote( slot.OutputMappings, buffer );
                    AppendMidiCc( slot.OutputMappings, buffer );
                    AppendMidiPc( slot.OutputMappings, buffer );

                    if( i > 0 )
                    {
                        buffer.Append( '\n' );
                    }

                    i++;
                }

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

        private void AppendMidiNote( IReadOnlyList<IMidiEvent> midiEvents, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( midiEvents, buffer ) )
            {
                return;
            }

            foreach( var midi in midiEvents )
            {
                if( midi.Status.Value < MidiStatusCode.NoteOn.Value ||
                    midi.Status.Value > MidiStatusCode.NoteOn.Value + 0x0F )
                {
                    continue;
                }

                buffer.Append(
                    MidiNoteName.FromMidiNoteNumber( new MidiNoteNumber( midi.DataByte1.Value ) )
                ).Append( TsvLine.Separator );

                buffer.Append( midi.DataByte2.Value ).Append( TsvLine.Separator );
            }
        }

        private void AppendMidiCc( IReadOnlyList<IMidiEvent> midiEvents, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( midiEvents, buffer ) )
            {
                return;
            }

            foreach( var midi in midiEvents )
            {
                if( midi.Status.Value < MidiStatusCode.ControlChange.Value ||
                    midi.Status.Value > MidiStatusCode.ControlChange.Value + 0x0F )
                {
                    continue;
                }

                buffer.Append( midi.DataByte1.Value ).Append( TsvLine.Separator );
                buffer.Append( midi.DataByte2.Value ).Append( TsvLine.Separator );
            }
        }

        private void AppendMidiPc( IReadOnlyList<IMidiEvent> midiEvents, StringBuilder buffer )
        {
            if( AppendSeparatorForEmptyList( midiEvents, buffer ) )
            {
                return;
            }

            foreach( var midi in midiEvents )
            {
                if( midi.Status.Value < MidiStatusCode.ProgramChange.Value ||
                    midi.Status.Value > MidiStatusCode.ProgramChange.Value + 0x0F )
                {
                    continue;
                }

                buffer.Append( midi.DataByte1.Value ).Append( TsvLine.Separator );
                buffer.Append( midi.DataByte2.Value ).Append( TsvLine.Separator );
            }
        }

    }
}