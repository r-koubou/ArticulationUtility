using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "InstrumentMap" )]
    public class RootElement
    {
        public string Name { get; set; }

        [XmlElement( ElementName = "string" )]
        public StringElement StringElement { get; set; }

        [XmlElement( ElementName = "member" )]
        public List<MemberElement> Member { get; set; } = new List<MemberElement>();

        public RootElement()
        {
        }

        public RootElement( string name )
        {
            StringElement = new StringElement( "name", name );
        }

        public RootElement( StringElement stringElement, List<MemberElement> members )
        {
            StringElement = stringElement;
            Member.AddRange( members );
        }
    }
}