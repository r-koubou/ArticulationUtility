using System;

using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate
{
    public class Articulation
    {
        public ArticulationId Id { get; }
        public ArticulationName Name { get; }
        public ArticulationType Type { get; }
        public ArticulationGroup Group { get; }

        public Articulation( ArticulationId id, ArticulationName name, ArticulationType type, ArticulationGroup group )
        {
            Id    = id ?? throw new ArgumentNullException( $"{nameof( id )}" );
            Name  = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            Type  = type;
            Group = group ?? throw new ArgumentNullException( $"{nameof( group )}" );
        }
    }
}