using System.Collections.Generic;

using ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Adapters.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class WorkbookAdapter : IExpressionMapAdapter<Workbook>
    {
        public List<ExpressionMap> Convert( Workbook workbook )
        {
            var result = new List<ExpressionMap>();

            foreach( var worksheet in workbook.Worksheets )
            {
                var name = new ExpressionMapName( worksheet.OutputNameCell.Value );
                var expressionMap = new ExpressionMap( name );

                ConvertRows( worksheet.Rows, expressionMap );

                result.Add( expressionMap );
            }
            return result;
        }

        private void ConvertRows( List<Row> rows, ExpressionMap expressionMap )
        {
            var idGenerator = new ArticulationIdGenerator();

            foreach( var row in rows )
            {
                var articulationId = idGenerator.Next();
                var articulationName = new ArticulationName( row.ArticulationName.Value );
                var articulationType = EnumHelper.Parse<ArticulationType>( row.ArticulationType.Value );
                var articulationGroup = new ArticulationGroup( row.GroupIndex.Value );
                var articulation = new Articulation( articulationId, articulationName, articulationType, articulationGroup );

                if( !expressionMap.Articulations.ContainsKey( articulationId ) )
                {
                    expressionMap.Articulations.Add( articulationId, articulation );
                }

                var slotName = new SoundSlotName( row.ArticulationName.Value );
                var slotColor = new SoundSlotColorIndex( row.ColorIndex.Value );
                var soundSlot = new SoundSlot( slotName, slotColor );

                // One articulation per SoundSlot in this convert.
                soundSlot.ReferenceArticulationIds.Add( articulation.Id );

                // To Midi note, CC, Program
                ConvertOutputMappings( row, soundSlot.OutputMappings );

                expressionMap.SoundSlots.Add( soundSlot );
            }
        }

        private void ConvertOutputMappings( Row row, List<IMidiEvent> target )
        {
            ConvertMidiNoteMapping( row, target );
            ConvertControlChangeMapping( row, target );
            ConvertProgramMapping( row, target );
        }

        private void ConvertMidiNoteMapping( Row row, List<IMidiEvent> target )
        {
            var noteNumberAdapter = new MidiNoteNumberCellToMidiNoteNumber();
            var noteVelocityAdapter = new MidiNoteVelocityCellToVelocity();

            foreach( var midiNote in row.MidiNoteList )
            {
                target.Add(
                    new MidiNoteOn(
                        noteNumberAdapter.Convert( midiNote.Note ),
                        noteVelocityAdapter.Convert( midiNote.Velocity )
                    )
                );
            }
        }

        private void ConvertControlChangeMapping( Row row, List<IMidiEvent> target )
        {
            var ccNumberAdapter = new MidiControlChangeNumberCellToControlNumber();
            var ccValueAdapter = new MidiControlChangeValueCellToControlValue();

            foreach( var cc in row.MidiControlChangeList )
            {
                target.Add(
                    new MidiControlChange(
                        ccNumberAdapter.Convert( cc.CcNumber ),
                        ccValueAdapter.Convert( cc.CcValue )
                    )
                );
            }
        }

        private void ConvertProgramMapping( Row row, List<IMidiEvent> target )
        {
            var programAdapter = new MidiProgramCellToProgram();

            foreach( var pc in row.MidiProgramChangeList )
            {
                target.Add( programAdapter.Convert( pc ) );
            }
        }

    }
}