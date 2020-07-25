using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public class ExpressionMapXmlRepository : IExpressionMapXmlRepository
    {
        public string LoadPath { get; set; }
        public string SavePath { get; set; }

        public InstrumentMapElement Load()
        {
            var deserializer = new XmlSerializer( typeof(InstrumentMapElement) );
            var settings = new XmlReaderSettings()
            {
                CheckCharacters = true
            };

            using var streamReader = new StreamReader( LoadPath, Encoding.UTF8 );
            using var xmlReader = XmlReader.Create( streamReader, settings );

            return (InstrumentMapElement)deserializer.Deserialize( xmlReader );
        }

        public void Save( InstrumentMapElement data )
        {
            var serializer = new XmlSerializer( typeof( InstrumentMapElement ) );

            // no xmlns adding
            // see: https://stackoverflow.com/a/8882612
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add( "", "" );

            using var writer = new StreamWriter( SavePath, false, Encoding.UTF8 );
            serializer.Serialize( writer, data, xmlNamespaces );
        }
    }
}