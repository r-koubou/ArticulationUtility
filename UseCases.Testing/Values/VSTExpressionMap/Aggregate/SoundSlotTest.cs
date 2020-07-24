using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;

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
                new ProgramEvent(
                    new ProgramEventValue( 1 )
                )
            );
        }
    }
}