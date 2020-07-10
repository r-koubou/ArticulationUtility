using System;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap
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