using System;

using ArticulationUtility.Entities.StudioOneKeySwitch.Value;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate
{
    public class KeySwitchElement
    {
        public KeySwitchName Name { get; }
        public KeySwitchPitch KeySwitchPitch { get; }

        public KeySwitchElement( KeySwitchName name, KeySwitchPitch pitch )
        {
            Name           = name ?? throw new ArgumentNullException( nameof( name ) );
            KeySwitchPitch = pitch ?? throw new ArgumentNullException( nameof( pitch ) );
        }
    }
}