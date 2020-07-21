using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "list" )]
    public class ListElement
    {
        [XmlElement( ElementName = "obj" )]
        public ObjectElement ObjectElement { get; set; }

        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlAttribute( AttributeName = "type" )]
        public string Type { get; set; }
    }
}