using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;

using NUnit.Framework;

namespace UseCases.Testing.Values.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class SoundSlotTest
    {

        [Test]
        public void ValueTest()
        {
            var idGenerator = new ArticulationIdGenerator();
            var slot = new SoundSlot( new SoundSlotName( "Name" ), new SoundSlotColorIndex( 0 ) );
            slot.ReferenceArticulationIds.Add( idGenerator.Next() );

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