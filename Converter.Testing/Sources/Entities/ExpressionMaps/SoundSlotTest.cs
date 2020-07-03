using System;

using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps;
using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps.Value;
using Spreadsheet2Expressionmap.Converter.Entities.MidiEvents;
using Spreadsheet2Expressionmap.Converter.Entities.MidiEvents.Value;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entities.ExpressionMaps
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