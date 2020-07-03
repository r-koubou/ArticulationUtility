using System;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps.Value;

namespace Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps
{
    public class Articulation
    {
        public ArticulationName Name { get; }
        public ArticulationType Type { get; }
        public ArticulationGroup Group { get; }

        public Articulation( ArticulationName name, ArticulationType type, ArticulationGroup group )
        {
            Name  = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            Type  = type;
            Group = @group ?? throw new ArgumentNullException( $"{nameof( @group )}" );
        }
    }
}