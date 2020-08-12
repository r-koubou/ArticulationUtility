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
            var keySwitch = new KeySwitch( new KeySwitchListName( "Test" ) );
            keySwitch.KeySwitchList.Add(
                new KeySwitchElement( new KeySwitchName( "Hoge" ), new KeySwitchPitch( 0 ) )
            );
        }
    }
}