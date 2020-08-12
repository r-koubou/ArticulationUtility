using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.StudioOneKeySwitch.Value;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate
{
    public class KeySwitch
    {
        public KeySwitchListName Name { get; }
        public List<KeySwitchElement> KeySwitchList { get; } = new List<KeySwitchElement>();

        public KeySwitch( KeySwitchListName name )
        {
            Name = name ?? throw new ArgumentNullException();
        }

    }
}