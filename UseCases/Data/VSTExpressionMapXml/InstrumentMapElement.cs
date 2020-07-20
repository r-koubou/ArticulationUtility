using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticulationUtility.UseCases.Data.VSTExpressionMapXml
{
    [XmlRoot( ElementName = "InstrumentMap" )]
    public class InstrumentMapElement
    {
        [XmlElement( ElementName = "string" )]
        public StringElement StringElement { get; set; }

        [XmlElement( ElementName = "member" )]
        public List<MemberElement> Member { get; set; }
    }
}