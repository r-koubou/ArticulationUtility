using System;

using ArticulationUtility.Entities.Helper;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    /// <summary>
    /// A Slot name
    /// </summary>
    public class SoundSlotName : IEquatable<SoundSlotName>
    {
        private string Name { get; }

        public SoundSlotName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
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
