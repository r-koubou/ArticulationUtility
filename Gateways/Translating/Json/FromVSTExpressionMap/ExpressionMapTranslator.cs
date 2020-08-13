using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;

using ArticulationJson = ArticulationUtility.UseCases.Values.Json.ForArticulation.Articulation;

namespace ArticulationUtility.Gateways.Translating.Json.FromVSTExpressionMap
{
    public class ExpressionMapTranslator : IDataTranslator<ExpressionMap, JsonRoot>
    {
        public JsonRoot Translate( ExpressionMap source )
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