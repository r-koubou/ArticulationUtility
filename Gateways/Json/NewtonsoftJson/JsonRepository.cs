using System.IO;

using Newtonsoft.Json;

using DestJsonRoot = ArticulationUtility.Entities.Json.Aggregate.JsonRoot;
using DestJsonInfo = ArticulationUtility.Entities.Json.Value.Info;
using DestMidiMappingInfo = ArticulationUtility.Entities.Json.Value.MidiMapping;
using DestJsonArticulation = ArticulationUtility.Entities.Json.Value.Articulation;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    public class JsonRepository : IJsonRepository
    {
        public string LoadPath { get; set; }

        public DestJsonRoot Load()
        {
            var srcRoot = JsonConvert.DeserializeObject<JsonRoot>( File.ReadAllText( LoadPath ) );
            var jsonRoot = new DestJsonRoot();

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
                var obj = new DestJsonArticulation();
                obj.Name  = articulation.Name;
                obj.Color = articulation.Color;
                obj.Type  = articulation.Type;
                obj.Group = articulation.Group;

                #region MidiMappings
                foreach( var mapping in articulation.MidiMappings )
                {
                    var midi = new Entities.Json.Value.MidiMapping();
                    midi.Status = mapping.Status;
                    midi.Data1 = mapping.Data1;
                    midi.Data2 = mapping.Data2;
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