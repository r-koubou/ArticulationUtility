using System.IO;

using Newtonsoft.Json;

using EntityJsonRoot = ArticulationUtility.Entities.Json.Articulation.JsonRoot;
using EntityJsonInfo = ArticulationUtility.Entities.Json.Articulation.Info;
using EntityMidiMapping = ArticulationUtility.Entities.Json.Articulation.MidiMapping;
using EntityJsonArticulation = ArticulationUtility.Entities.Json.Articulation.Articulation;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class JsonRepository : IJsonRepository
    {
        public string LoadPath { get; set; }

        public EntityJsonRoot Load()
        {
            var srcRoot = JsonConvert.DeserializeObject<JsonRoot>( File.ReadAllText( LoadPath ) );
            var jsonRoot = new EntityJsonRoot();

            jsonRoot.FormatVersion = srcRoot.FormatVersion;

            #region Info
            jsonRoot.Info.Version = srcRoot.Info.Version;
            jsonRoot.Info.Name    = srcRoot.Info.Name;
            jsonRoot.Info.Author  = srcRoot.Info.Author;
            jsonRoot.Info.Product = srcRoot.Info.Product;
            jsonRoot.Info.Url     = srcRoot.Info.Url;
            #endregion Info

            #region Articulations
            foreach( var articulation in srcRoot.Articulations )
            {
                var obj = new EntityJsonArticulation
                {
                    Name  = articulation.Name,
                    Color = articulation.Color,
                    Type  = articulation.Type,
                    Group = articulation.Group
                };

                #region MidiMappings
                foreach( var mapping in articulation.MidiMappings )
                {
                    var midi = new EntityMidiMapping
                    {
                        Status = mapping.Status,
                        Data1  = mapping.Data1,
                        Data2  = mapping.Data2
                    };
                    obj.MidiMappings.Add( midi );
                }
                #endregion

                jsonRoot.Articulations.Add( obj );
            }
            #endregion Articulations

            return jsonRoot;
        }
    }
}