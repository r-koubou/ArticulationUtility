using System.IO;
using System.Text;

using Newtonsoft.Json;

using EntityJsonRoot = ArticulationUtility.Entities.Json.Articulation.JsonRoot;
using ExternalJsonRoot = ArticulationUtility.Gateways.Json.NewtonsoftJson.JsonRoot;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class JsonRepository : IJsonRepository
    {
        public string LoadPath { get; set; }
        public string SavePath { get; set; }

        public EntityJsonRoot Load()
        {
            var json = JsonConvert.DeserializeObject<JsonRoot>( File.ReadAllText( LoadPath ) );
            var adapter = new NewtonJsonToEntity();
            return adapter.Convert( json );
        }

        public void Save( EntityJsonRoot data )
        {
            var adapter = new EntityToNewtonJson();
            var json = adapter.Convert( data );
            var text = JsonConvert.SerializeObject( json, Formatting.Indented );

            File.WriteAllText( SavePath, text, Encoding.UTF8 );
        }
    }
}