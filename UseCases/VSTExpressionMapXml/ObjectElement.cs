using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "obj" )]
    public class ObjectElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlElement( ElementName = "int" )]
        public List<IntElement> Int { get; set; } = new List<IntElement>();

        [XmlElement( ElementName = "float" )]
        public List<FloatElement> Float { get; set; } = new List<FloatElement>();

        [XmlElement( ElementName = "string" )]
        public List<StringElement> String { get; set; } = new List<StringElement>();

        [XmlAttribute( AttributeName = "class" )]
        public string ClassName { get; set; } = string.Empty;

        [XmlAttribute( AttributeName = "ID" )]
        public string Id { get; set; }

        [XmlElement( ElementName = "obj" )]
        public List<ObjectElement> Obj { get; set; } = new List<ObjectElement>();

        [XmlElement( ElementName = "member" )]
        public List<MemberElement> Member { get; set; } = new List<MemberElement>();

        public ObjectElement( string classNameName ) : this()
        {
            ClassName = classNameName;
        }

        public ObjectElement()
        {
            var guid = System.Guid.NewGuid().ToString();
            var hex = guid.Split( '-' )[ 0 ];
            Id = ( Convert.ToInt32( hex, 16 ) & 0x7ffffff ).ToString();
        }
    }
}