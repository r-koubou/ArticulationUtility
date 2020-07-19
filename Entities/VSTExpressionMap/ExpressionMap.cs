using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap
{
    /// <summary>
    /// Representing ExpressionMap aggregates
    /// </summary>
    public class ExpressionMap
    {
        public ExpressionMapName Name { get; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();
        public List<SoundSlot> SoundSlots { get; } = new List<SoundSlot>();

        public ExpressionMap( ExpressionMapName name = null )
        {
            Name = name ?? new ExpressionMapName( "default.out" );
        }
    }
}