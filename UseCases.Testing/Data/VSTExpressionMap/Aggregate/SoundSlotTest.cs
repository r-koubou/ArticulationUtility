using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Data.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Data.VSTExpressionMap.Value;

using NUnit.Framework;

namespace UseCases.Testing.Data.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class SoundSlotTest
    {

        [Test]
        public void ValueTest()
        {
            var slot = new SoundSlot( new SoundSlotName( "Name" ), new SoundSlotColorIndex( 0 ) );
            slot.Articulations.Add(
                new Articulation(
                    new ArticulationName( "Name" ),
                    ArticulationType.Direction,
                    new ArticulationGroup( 1 )
                )
            );
            slot.OutputMappings.Add(
                new MidiNoteOn(
                    new MidiNoteNumber( 1 ),
                    new MidiVelocity( 100 )
                )
            );
            slot.OutputMappings.Add(
                new MidiControlChange(
                    new MidiControlChangeNumber( 0 ),
                    new MidiControlChangeValue( 0 )
                )
            );
            slot.OutputMappings.Add(
                new MidiProgramChange(
                    new MidiLeastSignificantByte( 1 ),
                    new MidiMostSignificantByte( 2 )
                )
            );
        }
    }
}