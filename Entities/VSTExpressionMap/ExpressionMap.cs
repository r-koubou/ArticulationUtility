using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap
{
    /// <summary>
    /// Representing ExpressionMap aggregates
    /// </summary>
    public class ExpressionMap
    {
        public ExpressionMapName Name { get; set; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();

        public ExpressionMap( ExpressionMapName name )
        {
            Name = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
        }
    }
}