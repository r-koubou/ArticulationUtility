using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml.XmlClasses;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap
{
    public class ExpressionMapAdapter : IExpressionMapXmlAdapter<ExpressionMap, ExpressionMapXml>
    {
        public List<ExpressionMapXml> Convert( ExpressionMap source )
        {
            var result = new List<ExpressionMapXml>();

            var expressionMapXml = new ExpressionMapXml();
            var instrumentMapElement = InstrumentMap.New( source.Name.Value );

            var listOfUSlotVisuals = new ListElement();
            var listOfPSoundSlot = new ListElement();

            foreach( var slot in source.SoundSlots )
            {

                // slotvisuals
                foreach( var id in slot.ReferenceArticulationIds )
                {
                    var articulation = source.Articulations[ id ];
                    var slotVisual = USlotVisuals.New(
                        articulation.Name.Value,
                        articulation.Name.Value,
                        (int)articulation.Type,
                        articulation.Group.Value
                    );

                    // One articulation per SoundSlot in this convert.
                    listOfUSlotVisuals.Obj.Add( slotVisual );
                }

                var slotName = slot.Name;
                var slotColor = slot.ColorIndex.Value;

                // PSoundSlot
                var pSoundSlot = PSoundSlot.New( slotName.Value );
                pSoundSlot.Obj.Add( PSlotThruTrigger.New() );

                // POutputEvent
                var listOfPOutputEvent = new ListElement();
                ConvertOutputMappings( slot, listOfPOutputEvent );

                // slotMidiAction
                pSoundSlot.Obj.Add( PSlotMidiAction.New( listOfPOutputEvent ) );

                // sv
                foreach( var slotVisual in listOfUSlotVisuals.Obj )
                {
                    pSoundSlot.Member.Add( PSoundSlot.Sv( slotVisual ) );
                }

                // name
                pSoundSlot.Member.Add( PSoundSlot.Name( slotName.Value ) );

                //
                pSoundSlot.Int.Add( new IntElement( "color", slotColor ) );

                // Aggregate
                listOfPSoundSlot.Obj.Add( pSoundSlot );

            }

            // Construction of InstrumentMap element
            var slots = InstrumentMap.Slots( listOfPSoundSlot );
            var slotvisuals = InstrumentMap.Slotvisuals( listOfUSlotVisuals );

            instrumentMapElement.Member.Add( slotvisuals );
            instrumentMapElement.Member.Add( slots );

            // Construction of XML structure
            expressionMapXml.FileName    = source.Name.Value;
            expressionMapXml.RootElement = instrumentMapElement;
            result.Add( expressionMapXml );

            return result;
        }

        private void ConvertOutputMappings( SoundSlot slot, ListElement listOfPOutputEvent )
        {
            foreach( var midiEvent in slot.OutputMappings )
            {
                ConvertOutputMappingsImpl( midiEvent, listOfPOutputEvent );
            }
        }

        private void ConvertOutputMappingsImpl( IMidiEvent evt, ListElement listOfPOutputEvent )
        {
            var status = evt.Status.Value;
            var data1 = evt.DataByte1.Value;
            var data2 =  evt.DataByte2.Value;
            listOfPOutputEvent.Obj.Add( POutputEvent.New( status, data1, data2 ) );
        }
    }
}