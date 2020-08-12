using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromVSTExpressionMap
{
    public class ExpressionMapTranslator : IDataTranslator<RootElement, List<KeySwitch>>
    {
        public List<KeySwitch> Translate( RootElement source )
        {
            var expressionMapXmlTranslator = new ExpressionMapXmlTranslator();
            var vstExpressionMap = expressionMapXmlTranslator.Translate( source );

            var listName = new KeySwitchListName( vstExpressionMap.Name.Value );
            var keySwitch = new KeySwitch( listName );

            foreach( var slot in vstExpressionMap.SoundSlots )
            {
                var name = new KeySwitchName( slot.Name.Value );

                foreach( var midi in slot.OutputMappings )
                {
                    if( midi.Status.Value == MidiStatusCode.NoteOn.Value )
                    {
                        var pitch = new KeySwitchPitch( midi.DataByte1.Value );
                        keySwitch.KeySwitchList.Add( new KeySwitchElement( name, pitch  ) );
                        break;
                    }
                }
            }

            return new List<KeySwitch>{ keySwitch };
        }
    }
}