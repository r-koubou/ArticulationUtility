using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.UseCases.Values.Json.ForArticulation.Aggregate;

using ArticulationJson = ArticulationUtility.UseCases.Values.Json.ForArticulation.Value.Articulation;

namespace ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromJson
{
    public class JsonTranslator : IDataTranslator<JsonRoot, List<KeySwitch>>
    {
        public List<KeySwitch> Translate( JsonRoot source )
        {
            var keySwitch = new KeySwitch( new KeySwitchListName( source.Info.Name ) );

            foreach( var obj in source.Articulations )
            {
                // A Key switch
                var keySwitchElement = ParseArticulation( obj );
                keySwitch.KeySwitchList.Add( keySwitchElement );
            }

            return new List<KeySwitch> { keySwitch };
        }

        private static KeySwitchElement ParseArticulation( ArticulationJson obj )
        {

            foreach( var midi in obj.MidiMappings )
            {
                IMidiEvent mapping;

                switch( midi.Status )
                {
                    // alias format
                    case ArticulationJson.MidiStatusAlias.MidiNoteOn:
                    {
                        var noteName = new MidiNoteName( midi.Data1 );
                        return new KeySwitchElement(
                            new KeySwitchName( obj.Name ),
                            new KeySwitchPitch( noteName.ToMidiNoteNumber().Value )
                        );
                    }
                    break;
                    // direct value format ("123")
                    default:
                    {
                        if( int.Parse( midi.Status ) == MidiStatusCode.NoteOn.Value )
                        {
                            var noteName = new MidiNoteName( midi.Data1 );
                            return new KeySwitchElement(
                                new KeySwitchName( obj.Name ),
                                new KeySwitchPitch( noteName.ToMidiNoteNumber().Value )
                            );
                        }
                    }
                    break;
                }
            }

            throw new ArgumentException( $"{nameof(ArticulationJson)} : Not included ``" );
        }
    }
}