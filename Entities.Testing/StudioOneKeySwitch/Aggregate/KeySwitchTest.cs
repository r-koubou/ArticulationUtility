using System.Collections.Generic;

using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.StudioOneKeySwitch.Aggregate
{
    [TestFixture]
    public class KeySwitchTest
    {
        [Test]
        public void SetupKeySwitchTest()
        {
            var keySwitchList = new List<KeySwitchElement>
            {
                new KeySwitchElement(
                    new KeySwitchName( "Hoge" ),
                    new KeySwitchPitch( 0 ) )
            };

            var keySwitch = new KeySwitch(
                new KeySwitchListName( "Test" ),
                keySwitchList
            );
        }
    }
}