using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.StudioOneKeySwitch.Value;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;

using ArticulationJson = ArticulationUtility.UseCases.Values.Json.ForArticulation.Articulation;

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
                if( ParseArticulation( obj, out var element ) )
                {
                    keySwitch.KeySwitchList.Add( element );
                }
            }

            return new List<KeySwitch> { keySwitch };
        }

        private static bool ParseArticulation( ArticulationJson obj, out KeySwitchElement target )
        {
            target = default!;

            foreach( var midi in obj.MidiMappings )
            {
                switch( midi.Status )
                {
                    // alias format
                    case Articulation.MidiStatusAlias.MidiNoteOn:
                    {
                        var noteName = new MidiNoteName( midi.Data1 );
                        target = new KeySwitchElement(
                            new KeySwitchName( obj.Name ),
                            new KeySwitchPitch( noteName.ToMidiNoteNumber().Value )
                        );
                    }
                    return true;
                    // direct value format ("123")
                    default:
                    {
                        if( int.Parse( midi.Status ) == MidiStatusCode.NoteOn.Value )
                        {
                            var noteName = new MidiNoteName( midi.Data1 );
                            target = new KeySwitchElement(
                                new KeySwitchName( obj.Name ),
                                new KeySwitchPitch( noteName.ToMidiNoteNumber().Value )
                            );

                            return true;
                        }
                    }
                    break;
                }
            }

            return false;
        }
    }
}