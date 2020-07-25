using System;
using System.IO;

using Newtonsoft.Json;

using JsonRootObject = ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap.JsonRoot;
using JsonArticulationObject = ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap.Articulation;
using JsonOutputMappingObject = ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap.OutputMapping;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class JsonRepository : IJsonRepository
    {
        public string LoadPath { get; set; }

        public JsonRootObject Load()
        {
            var srcRoot = JsonConvert.DeserializeObject<JsonRoot>( File.ReadAllText( LoadPath ) );
            var jsonRoot = new JsonRootObject();

            jsonRoot.FormatVersion = srcRoot.FormatVersion;
            jsonRoot.Name = srcRoot.Name;

            foreach( var articulation in srcRoot.Articulations )
            {
                var obj = new JsonArticulationObject();
                obj.Name  = articulation.Name;
                obj.Color = articulation.Color;
                obj.Type  = articulation.Type;
                obj.Group = articulation.Group;

                foreach( var mapping in articulation.OutputMapping )
                {
                    var midi = new JsonOutputMappingObject();
                    midi.Status = mapping.Status;
                    midi.Data1 = mapping.Data1;
                    midi.Data2 = mapping.Data2;
                    obj.OutputMapping.Add( midi );
                }

                jsonRoot.Articulations.Add( obj );
            }

            return jsonRoot;
        }
    }
}