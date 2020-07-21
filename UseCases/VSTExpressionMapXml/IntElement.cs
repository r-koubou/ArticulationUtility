using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "int" )]
    public class IntElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; } = string.Empty;

        [XmlAttribute( AttributeName = "value" )]
        public int Value { get; set; } = 0;

        public IntElement()
        {}

        public IntElement( string name, int value )
        {
            Name  = name;
            Value = value;
        }
    }
}