using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    /// <summary>
    /// An Articulation name
    /// </summary>
    public class ArticulationName : IEquatable<ArticulationName>
    {
        private string Name { get; }

        public ArticulationName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
            Name = name;
        }

        public bool Equals( ArticulationName other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Name == Name;
        }

        public override string ToString() => Name;

    }
}
