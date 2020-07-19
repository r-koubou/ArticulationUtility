using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvents;
using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Entities.VSTExpressionMap;
using ArticulationUtility.Entities.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Adapters.VSTExpressionMap.Compat.Ver_0_7
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

            throw new NotImplementedException();
            return result;
        }

        private void ConvertRows( List<Row> rows, ExpressionMap expressionMap )
        {
            foreach( var row in rows )
            {
                var articulationName = new ArticulationName( row.ArticulationName.Value );
                var articulationType = EnumHelper.Parse<ArticulationType>( row.ArticulationType.Value );
                var articulationGroup = new ArticulationGroup( row.GroupIndex.Value );
                var articulation = new Articulation( articulationName, articulationType, articulationGroup );

                if( !expressionMap.Articulations.Contains( articulation ) )
                {
                    expressionMap.Articulations.Add( articulation );
                }

                var slotName = new SoundSlotName( row.ArticulationName.Value );
                var slotColor = new SoundSlotColorIndex( row.ColorIndex.Value );
                var soundSlot = new SoundSlot( slotName, slotColor );

                // 1 articulation per SoundSlot in this convert.
                soundSlot.Articulations.Add( articulation );

                ConvertOutputMappings( row, soundSlot.OutputMappings );

                expressionMap.SoundSlots.Add( soundSlot );


            }
        }

        private void ConvertOutputMappings( Row row, List<IMidiEvent> target )
        {
            foreach( var midiNote in row.MidiNoteList )
            {
                target.Add(
                    new MidiNoteOn(
                        MidiNoteNumber( midiNote.Note.Value ),
                        )
                    );
            }
        }

    }
}