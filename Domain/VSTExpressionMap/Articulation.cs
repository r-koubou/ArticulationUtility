using System;

using VSTExpressionMapTools.Domain.VSTExpressionMap.Value;

namespace VSTExpressionMapTools.Domain.VSTExpressionMap
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