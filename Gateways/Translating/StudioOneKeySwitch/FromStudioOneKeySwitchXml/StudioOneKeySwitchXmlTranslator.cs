using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml;

namespace ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromStudioOneKeySwitchXml
{
    public class StudioOneKeySwitchXmlTranslator : IDataTranslator<RootElement, KeySwitch>
    {
        public KeySwitch Translate( RootElement source )
        {
            var result = new KeySwitch( new KeySwitchListName( source.Name ) );

            foreach( var attribute in source.Attributes )
            {
                result.KeySwitchList.Add(
                    new KeySwitchElement(
                        new KeySwitchName( attribute.Name ),
                        new KeySwitchPitch( int.Parse( attribute.Pitch ) )
                    )
                );
            }

            return result;
        }
    }
}