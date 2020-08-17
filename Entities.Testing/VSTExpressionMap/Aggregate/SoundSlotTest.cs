using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

using NUnit.Framework;

namespace ArticulationUtility.Entities.Testing.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class SoundSlotTest
    {

        [Test]
        public void ValueTest()
        {
            var idGenerator = new ArticulationIdGenerator();

            var referenceArticulationIds = new List<ArticulationId>();
            referenceArticulationIds.Add( idGenerator.Next() );

            var outputMappings = new List<IMidiEvent>();
            outputMappings.Add(
                new MidiNoteOn(
                    new MidiNoteNumber( 1 ),
                    new MidiVelocity( 100 )
                )
            );
            outputMappings.Add(
                new MidiControlChange(
                    new MidiControlChangeNumber( 0 ),
                    new MidiControlChangeValue( 0 )
                )
            );
            outputMappings.Add(
                new MidiProgramChange(
                    new MidiProgramChangeChannel( 1 ),
                    new MidiProgramChangeNumber( 1 )
                )
            );

            var slot = new SoundSlot(
                new SoundSlotName( "Name" ),
                new SoundSlotColorIndex( 0 ),
                referenceArticulationIds,
                outputMappings
            );

        }
    }
}