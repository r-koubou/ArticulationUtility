using System.IO;
using System.Text;

using Newtonsoft.Json;

using EntityJsonRoot = ArticulationUtility.UseCases.Values.Json.Articulation.JsonRoot;
using ExternalJsonRoot = ArticulationUtility.Gateways.Json.NewtonsoftJson.JsonRoot;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class JsonFileRepository : IFileRepository<EntityJsonRoot>
    {
        public string Suffix { get; } = ".json";
        public string LoadPath { get; set; } = string.Empty;
        public string SavePath { get; set; } = string.Empty;

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