using System;
using System.Collections.Generic;

using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entity;
using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entity
{
    [TestFixture]
    public class SoundSlotTest
    {
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
                new OutputMapping(
                    new MidiNoteOn(
                        new MidiNoteNumber( 1 ),
                        new MidiVelocity( 100 )
                    )
                )
            );
            slot.OutputMappings.Add(
                new OutputMapping(
                    new MidiControlChange(
                        new MidiControlNumber( 0 ),
                        new MidiControlValue( 0 )
                    )
                )
            );
            slot.OutputMappings.Add(
                new OutputMapping(
                    new MidiProgramChangeByte(
                        new MidiLeastSignificantByte( 1 ),
                        new MidiMostSignificantByte( 2 )
                    )
                )
            );
        }
    }

    public class SoundSlot
    {
        public SoundSlotName Name { get; }
        public SoundSlotColorIndex ColorIndex { get; }
        public List<Articulation> Articulations { get; } = new List<Articulation>();

        public List<OutputMapping> OutputMappings { get; } = new List<OutputMapping>();

        public SoundSlot( SoundSlotName name, SoundSlotColorIndex colorIndex )
        {
            Name       = name ?? throw new ArgumentNullException( $"{nameof( name )}" );
            ColorIndex = colorIndex ?? throw new ArgumentNullException( $"{nameof( colorIndex )}" );
        }
    }
}