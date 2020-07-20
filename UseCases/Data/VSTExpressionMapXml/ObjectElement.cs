using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "obj" )]
    public class ObjectElement
    {
        [XmlElement( ElementName = "int" )]
        public List<IntElement> Int { get; set; }

        [XmlElement( ElementName = "string" )]
        public List<StringElement> String { get; set; }

        [XmlAttribute( AttributeName = "class" )]
        public string Class { get; set; }

        [XmlAttribute( AttributeName = "ID" )]
        public string ID { get; set; }

        [XmlElement( ElementName = "obj" )]
        public List<ObjectElement> Obj { get; set; }

        [XmlElement( ElementName = "member" )]
        public List<MemberElement> Member { get; set; }
    }
}