using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
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

        public bool Equals( [AllowNull] SoundSlotName other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;
    }
}
