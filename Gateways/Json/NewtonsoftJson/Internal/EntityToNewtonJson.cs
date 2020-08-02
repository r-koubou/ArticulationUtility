using ArticulationUtility.Adapters;

using EntityJsonRoot = ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate.JsonRoot;
using ExternalJsonRoot = ArticulationUtility.Gateways.Json.NewtonsoftJson.Internal.JsonRoot;
using ExternalMidiMapping = ArticulationUtility.Gateways.Json.NewtonsoftJson.Internal.MidiMapping;
using ExternalJsonArticulation = ArticulationUtility.Gateways.Json.NewtonsoftJson.Internal.Articulation;

namespace ArticulationUtility.Gateways.Json.NewtonsoftJson.Internal
{
    internal class EntityToNewtonJson : IDataAdapter<EntityJsonRoot, JsonRoot>
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