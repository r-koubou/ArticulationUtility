using System;
using System.Collections.Generic;

using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Entity
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