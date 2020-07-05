using System;
using System.Collections.Generic;

using VSTExpressionMapTools.Domain.VSTExpressionMap.Value;

namespace VSTExpressionMapTools.Domain.VSTExpressionMap
{
    /// <summary>
    /// Representing ExpressionMap aggregates
    /// </summary>
    public class ExpressionMap
    {
        public ExpressionMapName Name { get; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();

        public ExpressionMap( ExpressionMapName name )
        {
            Name = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
        }
    }
}