using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "list" )]
    public class ListElement
    {
        public List<ObjectElement> Obj { get; set; } = new List<ObjectElement>();

        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; } = string.Empty;

        [XmlAttribute( AttributeName = "type" )]
        public string Type { get; set; }

        public ListElement()
        {
            Name = "obj";
            Type = "obj";
        }

        public ListElement( string name, string type )
        {
            Name = name;
            Type = type;
        }
    }
}