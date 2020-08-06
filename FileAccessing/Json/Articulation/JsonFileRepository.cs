using System.IO;
using System.Text;

using ArticulationUtility.FileAccessing.Json.Articulation.Internal;
using ArticulationUtility.Gateways;

using Newtonsoft.Json;

using EntityJsonRoot = ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate.JsonRoot;
using ExternalJsonRoot = ArticulationUtility.FileAccessing.Json.Articulation.Internal.JsonRoot;

namespace ArticulationUtility.FileAccessing.Json.Articulation
{
    public class JsonFileRepository : IFileRepository<EntityJsonRoot>
    {
        public string Suffix { get; } = ".json";
        public string LoadPath { get; set; } = string.Empty;
        public string SavePath { get; set; } = string.Empty;

        public EntityJsonRoot Load()
        {
            var json = JsonConvert.DeserializeObject<ExternalJsonRoot>( File.ReadAllText( LoadPath ) );
            var translator = new NewtonJsonToEntity();
            return translator.Translate( json );
        }

        public void Save( EntityJsonRoot data )
        {
            var adapter = new EntityToNewtonJson();
            var json = adapter.Convert( data );
            var text = JsonConvert.SerializeObject( json, Formatting.Indented );

            Directory.CreateDirectory( Path.GetDirectoryName( SavePath ) );

            File.WriteAllText( SavePath, text, Encoding.UTF8 );
        }
    }
}