using ArticulationUtility.Translators;

using EntityJsonRoot = ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate.JsonRoot;
using EntityMidiMapping = ArticulationUtility.UseCases.Values.Json.ForArticulation.Value.MidiMapping;
using EntityJsonArticulation = ArticulationUtility.UseCases.Values.Json.ForArticulation.Value.Articulation;

namespace ArticulationUtility.FileAccessing.Json.Articulation.Internal
{
    internal class NewtonJsonToEntity : IExternalDataTranslator<JsonRoot, EntityJsonRoot>
    {
        public EntityJsonRoot Translate( JsonRoot source )
        {
            var json = new EntityJsonRoot
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

                json.Articulations.Add( obj );
            }
            #endregion Articulations

            return json;

        }
    }
}