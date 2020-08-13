using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml
{
    public class Attributes
    {
        [XmlAttribute( AttributeName = "pitch" )]
        public string Pitch { get; set; } = string.Empty;

        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; } = string.Empty;
    }
}