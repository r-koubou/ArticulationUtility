using ArticulationUtility.UseCases.Values.Json.Articulation;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;

using ArticulationJson = ArticulationUtility.UseCases.Values.Json.Articulation.Articulation;

namespace ArticulationUtility.Adapters.Json.FromVSTExpressionMap
{
    public class ExpressionMapAdapter : IDataAdapter<ExpressionMap, JsonRoot>
    {
        public JsonRoot Convert( ExpressionMap source )
        {
            var json = new JsonRoot
            {
                Info =
                {
                    Name    = source.Name.Value,
                    Version = "1.0.0"
                }
            };

            #region Articulations
            foreach( var slot in source.SoundSlots )
            {
                var obj = new ArticulationJson();
                foreach( var id in slot.ReferenceArticulationIds )
                {
                    var articulation = source.Articulations[ id ];
                    obj.Name = articulation.Name.Value;
                    obj.Type = articulation.Type.ToString();
                    obj.Color = slot.ColorIndex.Value;
                    obj.Group = articulation.Group.Value;
                }

                foreach( var midi in slot.OutputMappings )
                {
                    var mapping = new MidiMapping
                    {
                        Status = midi.Status.Value.ToString(),
                        Data1  = midi.DataByte1.Value.ToString(),
                        Data2  = midi.DataByte2.Value.ToString()
                    };
                    obj.MidiMappings.Add( mapping );
                }

                json.Articulations.Add( obj );
            }
            #endregion

            return json;
        }
    }
}