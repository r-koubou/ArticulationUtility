using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromStudioOneKeySwitch
{
    public class StudioOneKeySwitchTranslator : IDataTranslator<KeySwitch, List<ExpressionMap>>
    {
        public List<ExpressionMap> Translate( KeySwitch source )
        {
            var name = new ExpressionMapName( source.Name.Value );
            var articulations = new Dictionary<ArticulationId, Articulation>();
            var soundSlots = new List<SoundSlot>();

            var idGenerator = new ArticulationIdGenerator();

            foreach( var element in source.KeySwitchList )
            {
                // Articulation
                var articulationId = idGenerator.Next();
                var articulation = ParseArticulation( element, articulationId );
                articulations.Add( articulationId, articulation );

                // SoundSlot
                var soundSlot = ParseSoundSlot( element, articulationId );
                soundSlots.Add( soundSlot );
            }

            // Aggregate Expressionmap
            var expressionMap = new ExpressionMap(
                name,
                articulations,
                soundSlots
            );

            return  new List<ExpressionMap> { expressionMap };
        }

        private static Articulation ParseArticulation( KeySwitchElement obj, ArticulationId articulationId )
        {
            var articulationName = new ArticulationName( obj.Name.Value );
            var articulationType = ArticulationType.Direction;
            var articulationGroup = new ArticulationGroup( ArticulationGroup.MinValue );
            var articulation = new Articulation( articulationId, articulationName, ArticulationSymbol.None, articulationType, articulationGroup );

            return articulation;
        }

        private static SoundSlot ParseSoundSlot( KeySwitchElement obj, ArticulationId articulationId )
        {
            var name = new SoundSlotName( obj.Name.Value );
            var colorIndex = new SoundSlotColorIndex( SoundSlotColorIndex.MinValue  );
            var referenceArticulationIds = new List<ArticulationId>();
            var outputMappings = new List<IMidiEvent>();

            referenceArticulationIds.Add( articulationId );

            var noteName = new MidiNoteName( obj.KeySwitchPitch.Value.ToString() );
            var velocity = MidiVelocity.MinValue;
            var mapping = new MidiNoteOn( noteName.ToMidiNoteNumber(), new MidiVelocity( velocity ) );

            outputMappings.Add( mapping );

            return new SoundSlot(
                name,
                colorIndex,
                referenceArticulationIds,
                outputMappings
            );
        }
    }
}