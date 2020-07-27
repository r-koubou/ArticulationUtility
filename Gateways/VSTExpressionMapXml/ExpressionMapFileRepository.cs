using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public class ExpressionMapFileRepository : IFileRepository<RootElement>
    {
        public string Suffix { get; } = ".expressionmap";
        public string LoadPath { get; set; }
        public string SavePath { get; set; }

        public RootElement Load()
        {
            var deserializer = new XmlSerializer( typeof(RootElement) );
            var settings = new XmlReaderSettings()
            {
                CheckCharacters = true
            };

            using var streamReader = new StreamReader( LoadPath, Encoding.UTF8 );
            using var xmlReader = XmlReader.Create( streamReader, settings );

            return (RootElement)deserializer.Deserialize( xmlReader );
        }

        public void Save( RootElement data )
        {
            var serializer = new XmlSerializer( typeof( RootElement ) );

            // no xmlns adding
            // see: https://stackoverflow.com/a/8882612
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add( "", "" );

            using var writer = new StreamWriter( SavePath, false, Encoding.UTF8 );
            serializer.Serialize( writer, data, xmlNamespaces );
        }
    }
}