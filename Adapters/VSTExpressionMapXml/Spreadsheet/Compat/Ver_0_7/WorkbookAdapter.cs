using System.Collections.Generic;

using ArticulationUtility.Adapters.MidiEvent.Spreadsheet;
using ArticulationUtility.UseCases.Spreadsheet.Aggregate;
using ArticulationUtility.UseCases.VSTExpressionMap.Value;
using ArticulationUtility.UseCases.VSTExpressionMapXml;
using ArticulationUtility.UseCases.VSTExpressionMapXml.Classes;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml.Spreadsheet.Compat.Ver_0_7
{
    public class WorkbookAdapter : IExpressionMapXmlAdapter<Workbook>
    {
        public List<InstrumentMapElement> Convert( Workbook workbook )
        {
            var result = new List<InstrumentMapElement>();

            foreach( var worksheet in workbook.Worksheets )
            {
                var rootElement = new InstrumentMapElement( worksheet.OutputNameCell.Value );
                ConvertRows( worksheet.Rows, rootElement );

                result.Add( rootElement );
            }

            return result;
        }

        private void ConvertRows( List<Row> rows, InstrumentMapElement xmlRoot )
        {
            var slotvisuals = new MemberElement();
            var listOfUSlotVisuals = new ListElement();

            var slots       = new MemberElement();
            var listOfPSoundSlot = new ListElement();

            foreach( var row in rows )
            {
                var articulationName = row.ArticulationName.Value;
                var articulationType = EnumHelper.Parse<ArticulationType>( row.ArticulationType.Value );
                var articulationGroup = row.GroupIndex.Value;

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
                pSoundSlot.Member.Add( PSoundSlot.Sv( listOfUSlotVisuals ) );

                // name
                pSoundSlot.Member.Add( PSoundSlot.Name( slotName ) );

                //
                pSoundSlot.Int.Add( new IntElement( "color", slotColor ) );

                // Aggregate
                listOfPSoundSlot.Obj.Add( pSoundSlot );




            }

            slotvisuals.List.Add( listOfUSlotVisuals );
            slots.List.Add( listOfPSoundSlot );

            xmlRoot.Member.Add( slotvisuals );
            xmlRoot.Member.Add( slots );
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
            var pcLsbAdapter = new MidiProgramChangeLsbCellToPcLsb();
            var pcMsbAdapter = new MidiProgramChangeMsbCellToPcMsb();

            foreach( var pc in row.MidiProgramChangeList )
            {
                var data1 = pcLsbAdapter.Convert( pc.Lsb ).Value;
                var data2 =  pcMsbAdapter.Convert( pc.Msb ).Value;
                var outputEvent = POutputEvent.New( 192, data1, data2 );
                listOfPOutputEvent.Obj.Add( outputEvent );
            }
        }

    }
}