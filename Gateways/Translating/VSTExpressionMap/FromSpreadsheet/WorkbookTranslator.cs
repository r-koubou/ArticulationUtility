using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;
using ArticulationUtility.Gateways.Translating.MidiEvent.FromSpreadsheet;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Aggregate;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromSpreadsheet
{
    public class WorkbookTranslator : IDataTranslator<Workbook, List<ExpressionMap>>
    {
        public List<ExpressionMap> Translate( Workbook workbook )
        {
            var result = new List<ExpressionMap>();

            foreach( var worksheet in workbook.Worksheets )
            {
                var name = new ExpressionMapName( worksheet.OutputNameCell.Value );

                ConvertRows(
                    worksheet.Rows,
                    out var articulations,
                    out var soundSlots
                );

                var expressionMap = new ExpressionMap(
                    name,
                    articulations,
                    soundSlots
                );

                result.Add( expressionMap );
            }
            return result;
        }

        private void ConvertRows(
            IEnumerable<Row> rows,
            out Dictionary<ArticulationId, Articulation> articulations,
            out List<SoundSlot> soundSlots )
        {
            var idGenerator = new ArticulationIdGenerator();

            articulations = new Dictionary<ArticulationId, Articulation>();
            soundSlots    = new List<SoundSlot>();

            foreach( var row in rows )
            {
                var articulationId = idGenerator.Next();
                var articulationName = new ArticulationName( row.ArticulationName.Value );
                var articulationType = EnumHelper.Parse( row.ArticulationType.Value, ArticulationType.Default );
                var articulationGroup = new ArticulationGroup( row.GroupIndex.Value );
                var articulation = new Articulation( articulationId, articulationName, ArticulationSymbol.None, articulationType, articulationGroup );

                if( !articulations.ContainsKey( articulationId ) )
                {
                    articulations.Add( articulationId, articulation );
                }

                var slotName = new SoundSlotName( row.ArticulationName.Value );
                var slotColor = new SoundSlotColorIndex( row.ColorIndex.Value );
                var soundSlot = new SoundSlot( slotName, slotColor );

                // One articulation per SoundSlot in this convert.
                soundSlot.ReferenceArticulationIds.Add( articulation.Id );

                // To Midi note, CC, Program
                ConvertOutputMappings( row, soundSlot.OutputMappings );

                soundSlots.Add( soundSlot );
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
                        noteNumberAdapter.Translate( midiNote.Note ),
                        noteVelocityAdapter.Translate( midiNote.Velocity )
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
                        ccNumberAdapter.Translate( cc.CcNumber ),
                        ccValueAdapter.Translate( cc.CcValue )
                    )
                );
            }
        }

        private void ConvertProgramMapping( Row row, List<IMidiEvent> target )
        {
            var programAdapter = new MidiProgramCellToProgram();

            foreach( var pc in row.MidiProgramChangeList )
            {
                target.Add( programAdapter.Translate( pc.Data ) );
            }
        }

    }
}