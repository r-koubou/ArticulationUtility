using System.Collections.Generic;

using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml;

namespace ArticulationUtility.Gateways.Translating.StudioOneKeySwitchXml.FromStudioOneKeySwitch
{
    public class StudioOneKeySwitchTranslator : IDataTranslator<KeySwitch, List<RootElement>>
    {
        public List<RootElement> Translate( KeySwitch source )
        {
            var xml = new RootElement
            {
                Name = source.Name.Value
            };

            foreach( var element in source.KeySwitchList )
            {
                var attr = new Attributes
                {
                    Name  = element.Name.Value,
                    Pitch = element.KeySwitchPitch.Value.ToString()
                };
                xml.Attributes.Add( attr );
            }

            return new List<RootElement>{ xml };
        }
    }
}