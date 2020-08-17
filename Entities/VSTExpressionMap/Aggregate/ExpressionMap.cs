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
        public IReadOnlyDictionary<ArticulationId, Articulation> Articulations { get; }
        public IReadOnlyList<SoundSlot> SoundSlots { get; }

        public ExpressionMap(
            ExpressionMapName name,
            IReadOnlyDictionary<ArticulationId, Articulation> articulations,
            IEnumerable<SoundSlot> soundSlots )
        {
            Name          = name;
            Articulations = new Dictionary<ArticulationId, Articulation>( articulations );
            SoundSlots    = new List<SoundSlot>( soundSlots );
        }

    }
}