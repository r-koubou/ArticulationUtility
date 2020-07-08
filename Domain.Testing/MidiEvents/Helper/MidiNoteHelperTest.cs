using ArticulationUtility.Domain.MidiEvents.Helper;

using NUnit.Framework;

namespace ArticulationUtility.Domain.Testing.MidiEvents.Helper
{
    [TestFixture]
    public class MidiNoteHelperTest
    {
        [Test]
        public void NullTest()
        {
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.FromNoteName( null ) );
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.FromNoteName( "" ) );
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.ToNoteName( null ) );
        }


        [Test]
        [TestCase( "C-1 (12)" )]
        [TestCase( "C1 (36)" )]
        [TestCase( "C-1" )]
        [TestCase( "C1" )]
        public void CreateTest( string noteName )
        {
            MidiNoteHelper.FromNoteName( noteName );
        }

    }
}