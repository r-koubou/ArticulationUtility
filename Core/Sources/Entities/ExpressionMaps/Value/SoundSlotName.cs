using System;

namespace VSTExpressionMap.Core.Entities.ExpressionMaps.Value
{
    /// <summary>
    /// A Slot name
    /// </summary>
    public class SoundSlotName : IEquatable<SoundSlotName>
    {
        private string Name { get; }

        public SoundSlotName( string name )
        {
            if( string.IsNullOrEmpty( name ) || name.Trim().Length == 0 )
            {
                throw new System.ArgumentException( $"{nameof(name)} is null or empty" );
            }
            Name = name;
        }

        public bool Equals( SoundSlotName other )
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
