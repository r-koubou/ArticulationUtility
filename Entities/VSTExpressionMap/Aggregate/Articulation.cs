using System;

using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Entities.VSTExpressionMap.Aggregate
{
    public class Articulation
    {
        public ArticulationId Id { get; }
        public ArticulationName Name { get; }
        public ArticulationSymbol Symbol { get; }
        public ArticulationType Type { get; }
        public ArticulationGroup Group { get; }

        public Articulation( ArticulationId id, ArticulationName name, ArticulationSymbol symbol, ArticulationType type, ArticulationGroup group )
        {
            Id     = id ?? throw new ArgumentNullException( $"{nameof( id )}" );
            Name   = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            Symbol = symbol;
            Type   = type;
            Group  = group ?? throw new ArgumentNullException( $"{nameof( group )}" );
        }
    }
}