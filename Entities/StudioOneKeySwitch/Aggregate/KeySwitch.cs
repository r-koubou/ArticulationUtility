using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.StudioOneKeySwitch.Value;

namespace ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate
{
    public class KeySwitch
    {
        public KeySwitchListName Name { get; }
        public IReadOnlyList<KeySwitchElement> KeySwitchList { get; }

        public KeySwitch( KeySwitchListName name, IEnumerable<KeySwitchElement> keySwitchList )
        {
            Name          = name ?? throw new ArgumentNullException();
            KeySwitchList = new List<KeySwitchElement>( keySwitchList );
        }

    }
}