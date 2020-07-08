using System;

using ArticulationUtility.Domain.MidiEvents;
using ArticulationUtility.Domain.MidiEvents.Value;
using ArticulationUtility.Domain.VSTExpressionMap;
using ArticulationUtility.Domain.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Domain.Testing.VSTExpressionMap.ExpressionMaps
{
    [TestFixture]
    public class SoundSlotTest
    {
        [Test]
        public void NullTest()
        {
            Assert.Throws<ArgumentNullException>( () => new SoundSlot( null ) );
        }

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
                new OutputMapping().AddMidiEvent(
                    new MidiNoteOn(
                        new MidiNoteNumber( 1 ),
                        new MidiVelocity( 100 )
                    )
                )
            );
            slot.OutputMappings.Add(
                new OutputMapping().AddMidiEvent(
                    new MidiControlChange(
                        new MidiControlNumber( 0 ),
                        new MidiControlValue( 0 )
                    )
                )
            );
            slot.OutputMappings.Add(
                new OutputMapping().AddMidiEvent(
                    new MidiProgramChange(
                        new MidiLeastSignificantByte( 1 ),
                        new MidiMostSignificantByte( 2 )
                    )
                )
            );
        }
    }
}