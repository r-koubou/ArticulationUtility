using ArticulationUtility.Adapters;

using EntityJsonRoot = ArticulationUtility.Entities.Json.Articulation.JsonRoot;
using EntityJsonInfo = ArticulationUtility.Entities.Json.Articulation.Info;
using EntityMidiMapping = ArticulationUtility.Entities.Json.Articulation.MidiMapping;
using EntityJsonArticulation = ArticulationUtility.Entities.Json.Articulation.Articulation;

using ExternalJsonRoot = ArticulationUtility.Gateways.Json.NewtonsoftJson.JsonRoot;
using ExternalJsonInfo = ArticulationUtility.Gateways.Json.NewtonsoftJson.Info;
using ExternalMidiMapping = ArticulationUtility.Gateways.Json.NewtonsoftJson.MidiMapping;
using ExternalJsonArticulation = ArticulationUtility.Gateways.Json.NewtonsoftJson.Articulation;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson
{
    internal class EntityToNewtonJson : IDataAdapter<EntityJsonRoot, ExternalJsonRoot>
    {
        public ExternalJsonRoot Convert( EntityJsonRoot source )
        {
            var json = new ExternalJsonRoot
            {
                FormatVersion = source.FormatVersion,
                Info =
                {
                    Version     = source.Info.Version,
                    Name        = source.Info.Name,
                    Author      = source.Info.Author,
                    Product     = source.Info.Product,
                    Url         = source.Info.Url,
                    Description = source.Info.Description
                }
            };

            #region Articulations
            foreach( var articulation in source.Articulations )
            {
                var obj = new ExternalJsonArticulation
                {
                    Name  = articulation.Name,
                    Color = articulation.Color,
                    Type  = articulation.Type,
                    Group = articulation.Group
                };

                #region MidiMappings
                foreach( var mapping in articulation.MidiMappings )
                {
                    var midi = new ExternalMidiMapping
                    {
                        Status = mapping.Status,
                        Data1  = mapping.Data1,
                        Data2  = mapping.Data2
                    };
                    obj.MidiMappings.Add( midi );
                }
                #endregion

                json.Articulations.Add( obj );
            }
            #endregion Articulations

            return json;

        }
    }
}