using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "int" )]
    public class IntElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlAttribute( AttributeName = "value" )]
        public string Value { get; set; }
    }
}