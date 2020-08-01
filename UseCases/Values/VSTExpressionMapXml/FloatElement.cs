using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "float" )]
    public class FloatElement
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; } = string.Empty;

        [XmlAttribute( AttributeName = "value" )]
        public float Value { get; set; }

        public FloatElement()
        {
        }
        public FloatElement( string name, float value )
        {
            Name  = name;
            Value = value;
        }
    }
}