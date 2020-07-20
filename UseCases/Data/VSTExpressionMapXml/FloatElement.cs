using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "float" )]
    public class FloatElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlAttribute( AttributeName = "value" )]
        public string Value { get; set; }
    }
}