using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap.Aggregate
{
    /// <summary>
    /// Representing ExpressionMap aggregates
    /// </summary>
    public class ExpressionMap
    {
        public ExpressionMapName Name { get; }
        public Dictionary<ArticulationId, Articulation> Articulations { get; } = new Dictionary<ArticulationId, Articulation>();
        public List<SoundSlot> SoundSlots { get; } = new List<SoundSlot>();

        public ExpressionMap( ExpressionMapName name )
        {
            Name = name;
        }
    }
}