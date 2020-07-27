using System.Collections.Generic;

using ArticulationUtility.Entities;
using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml.XmlClasses;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap
{
    public class ExpressionMapAdapter : IDataAdapter<ExpressionMap, List<RootElement>>
    {
        public List<RootElement> Convert( ExpressionMap source )
        {
            var result = new List<RootElement>();

            #region List of USlotVisuals
            var listOfUSlotVisuals = new ListElement();

            foreach( var articulation in source.Articulations.Values )
            {
                var slotVisual = USlotVisuals.New(
                    articulation.Name.Value,
                    articulation.Name.Value,
                    (int)articulation.Type,
                    articulation.Group.Value
                );
                listOfUSlotVisuals.Obj.Add( slotVisual );
            }
            #endregion List of USlotVisuals

            #region List of PSoundSlot
            var listOfPSoundSlot = new ListElement();

            foreach( var slot in source.SoundSlots )
            {
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
                foreach( var id in slot.ReferenceArticulationIds )
                {
                    var articulation = source.Articulations[ id ];
                    var slotVisual = USlotVisuals.New(
                        articulation.Name.Value,
                        articulation.Name.Value,
                        (int)articulation.Type,
                        articulation.Group.Value
                    );

                    pSoundSlot.Member.Add( PSoundSlot.Sv( slotVisual ) );
                }

                // name
                pSoundSlot.Member.Add( PSoundSlot.Name( slotName.Value ) );

                //
                pSoundSlot.Int.Add( new IntElement( "color", slotColor ) );

                // Aggregate
                listOfPSoundSlot.Obj.Add( pSoundSlot );

            }
            #endregion List of PSoundSlot

            // Construction of InstrumentMap element
            var slots = InstrumentMap.Slots( listOfPSoundSlot );
            var slotvisuals = InstrumentMap.Slotvisuals( listOfUSlotVisuals );

            var instrumentMapElement = InstrumentMap.New( source.Name.Value );
            instrumentMapElement.Member.Add( slotvisuals );
            instrumentMapElement.Member.Add( slots );
            instrumentMapElement.Name = source.Name.Value;

            result.Add( instrumentMapElement );

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