using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "member" )]
    public class MemberElement
    {
        [XmlElement( ElementName = "int" )]
        public IntElement IntElement { get; set; }

        [XmlElement( ElementName = "list" )]
        public ListElement ListElement { get; set; }

        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }
    }
}