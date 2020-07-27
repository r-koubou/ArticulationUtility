using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    /// <summary>
    /// A Slot name
    /// </summary>
    public class SoundSlotName : IEquatable<SoundSlotName>
    {
        public string Value { get; }

        public SoundSlotName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
            Value = name;
        }

        public bool Equals( SoundSlotName other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value;
    }
}
