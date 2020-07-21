using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "InstrumentMap" )]
    public class InstrumentMapElement
    {
        [XmlElement( ElementName = "string" )]
        public StringElement StringElement { get; set; }

        [XmlElement( ElementName = "member" )]
        public List<MemberElement> Member { get; set; } = new List<MemberElement>();

        public InstrumentMapElement()
        {
        }

        public InstrumentMapElement( string name )
        {
            StringElement = new StringElement( "name", name );
        }

        public InstrumentMapElement( StringElement stringElement, List<MemberElement> members )
        {
            StringElement = stringElement;
            Member.AddRange( members );
        }
    }
}