using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Value
{
    /// <summary>
    /// A KeySwitch name
    /// </summary>
    public class KeySwitchName : IEquatable<KeySwitchName>
    {
        public string Value { get; }

        public KeySwitchName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
            Value = name;
        }

        public bool Equals( [AllowNull] KeySwitchName other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;

    }
}
