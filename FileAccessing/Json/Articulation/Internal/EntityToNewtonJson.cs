using ArticulationUtility.Adapters;

using EntityJsonRoot = ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate.JsonRoot;

namespace ArticulationUtility.FileAccessing.Json.Articulation.Internal
{
    internal class EntityToNewtonJson : IDataAdapter<EntityJsonRoot, JsonRoot>
    {
        public JsonRoot Convert( EntityJsonRoot source )
        {
            var json = new JsonRoot
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
                var obj = new Articulation
                {
                    Name  = articulation.Name,
                    Color = articulation.Color,
                    Type  = articulation.Type,
                    Group = articulation.Group
                };

                #region MidiMappings
                foreach( var mapping in articulation.MidiMappings )
                {
                    var midi = new MidiMapping
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