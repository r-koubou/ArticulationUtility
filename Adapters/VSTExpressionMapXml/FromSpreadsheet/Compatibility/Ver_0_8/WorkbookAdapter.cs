using System.Collections.Generic;

using ArticulationUtility.Adapters.MidiEvent.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml.XmlClasses;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml.FromSpreadsheet.Compatibility.Ver_0_8
{
    public class WorkbookAdapter : IExpressionMapXmlAdapter<Workbook, ExpressionMapXml>
    {
        public List<ExpressionMapXml> Convert( Workbook workbook )
        {
            var result = new List<ExpressionMapXml>();

            foreach( var worksheet in workbook.Worksheets )
            {
                var expressionMap = new ExpressionMapXml();
                ConvertRows( worksheet.Rows, expressionMap, worksheet.OutputNameCell.Value );

                result.Add( expressionMap );
            }

            return result;
        }

        private void ConvertRows( List<Row> rows, ExpressionMapXml target, string expressionMapName )
        {
            var instrumentMap = InstrumentMap.New( expressionMapName );
            var listOfUSlotVisuals = new ListElement();

            var listOfPSoundSlot = new ListElement();

            foreach( var row in rows )
            {
                var articulationName = row.ArticulationName.Value;
                var articulationType = EnumHelper.Parse<ArticulationType>( row.ArticulationType.Value );
                var articulationGroup = row.GroupIndex.Value - 1; // xml data is zero origin

                // if( !xmlRoot.Articulations.Contains( articulation ) )
                // {
                //     xmlRoot.Articulations.Add( articulation );
                // }

                var slotName = row.ArticulationName.Value;
                var slotColor = row.ColorIndex.Value;

                // slotvisuals
                var slotVisual = USlotVisuals.New(
                    slotName,
                    slotName,
                    (int)articulationType,
                    articulationGroup
                );

                // One articulation per SoundSlot in this convert.
                listOfUSlotVisuals.Obj.Add( slotVisual );

                // PSoundSlot
                var pSoundSlot = PSoundSlot.New( articulationName );
                pSoundSlot.Obj.Add( PSlotThruTrigger.New() );

                // POutputEvent
                var listOfPOutputEvent = new ListElement();
                ConvertOutputMappings( row, listOfPOutputEvent );

                // slotMidiAction
                pSoundSlot.Obj.Add( PSlotMidiAction.New( listOfPOutputEvent ) );

                // sv
                pSoundSlot.Member.Add( PSoundSlot.Sv( slotVisual ) );

                // name
                pSoundSlot.Member.Add( PSoundSlot.Name( slotName ) );

                //
                pSoundSlot.Int.Add( new IntElement( "color", slotColor ) );

                // Aggregate
                listOfPSoundSlot.Obj.Add( pSoundSlot );

            }

            var slots = InstrumentMap.Slots( listOfPSoundSlot );
            var slotvisuals = InstrumentMap.Slotvisuals( listOfUSlotVisuals );

            instrumentMap.Member.Add( slotvisuals );
            instrumentMap.Member.Add( slots );

            target.FileName    = expressionMapName;
            target.RootElement = instrumentMap;
        }

        private void ConvertOutputMappings( Row row, ListElement listOfPOutputEvent )
        {
            ConvertMidiNoteMapping( row, listOfPOutputEvent );
            ConvertControlChangeMapping( row, listOfPOutputEvent );
            ConvertProgramChangeMapping( row, listOfPOutputEvent );
        }

        private void ConvertMidiNoteMapping( Row row, ListElement listOfPOutputEvent )
        {
            var noteNumberAdapter = new MidiNoteNumberCellToMidiNoteNumber();
            var noteVelocityAdapter = new MidiNoteVelocityCellToVelocity();

            foreach( var midiNote in row.MidiNoteList )
            {
                var data1 = noteNumberAdapter.Convert( midiNote.Note ).Value;
                var data2 =  noteVelocityAdapter.Convert( midiNote.Velocity ).Value;
                var outputEvent = POutputEvent.New( 144, data1, data2 );
                listOfPOutputEvent.Obj.Add( outputEvent );
            }
        }

        private void ConvertControlChangeMapping( Row row, ListElement listOfPOutputEvent )
        {
            var ccNumberAdapter = new MidiControlChangeNumberCellToControlNumber();
            var ccValueAdapter = new MidiControlChangeValueCellToControlValue();

            foreach( var cc in row.MidiControlChangeList )
            {
                var data1 = ccNumberAdapter.Convert( cc.CcNumber ).Value;
                var data2 =  ccValueAdapter.Convert( cc.CcValue ).Value;
                var outputEvent = POutputEvent.New( 176, data1, data2 );
                listOfPOutputEvent.Obj.Add( outputEvent );
            }
        }

        private void ConvertProgramChangeMapping( Row row, ListElement listOfPOutputEvent )
        {
            var programAdapter = new MidiProgramCellToProgram();

            foreach( var pc in row.MidiProgramChangeList )
            {
                var data1 = programAdapter.Convert( pc ).DataByte1.Value;
                var data2 =  0;
                var outputEvent = POutputEvent.New( 192, data1, data2 );
                listOfPOutputEvent.Obj.Add( outputEvent );
            }
        }

    }
}