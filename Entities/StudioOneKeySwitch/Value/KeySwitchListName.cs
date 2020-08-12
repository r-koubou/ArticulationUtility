using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Value
{
    /// <summary>
    /// A KeySwitch list name (Preset/File name)
    /// </summary>
    public class KeySwitchListName : IEquatable<KeySwitchName>
    {
        public string Value { get; }

        public KeySwitchListName( string name )
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
