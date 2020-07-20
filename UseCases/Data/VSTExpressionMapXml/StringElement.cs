using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "string" )]
    public class StringElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlAttribute( AttributeName = "value" )]
        public string Value { get; set; }

        [XmlAttribute( AttributeName = "wide" )]
        public bool Wide { get; set; } = false;
    }
}