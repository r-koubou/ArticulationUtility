using System;
using System.Collections.Generic;
using System.Linq;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml
{
    public class ExpressionMapXmlTranslator : IDataTranslator<RootElement, ExpressionMap>
    {
        public ExpressionMap Translate( RootElement source )
        {
            var result = new ExpressionMap( new ExpressionMapName( source.StringElement.Value ) );
            var psoundSlot = PSoundSlot( source );

            var idGenerator = new ArticulationIdGenerator();

            var objectElements = psoundSlot.ToList();

            foreach( var slot in objectElements )
            {
                var sv = Sv( slot );

                if( !USlotVisuals( sv, out var uslotVisuals ) )
                {
                    continue;
                }

                var articulationName = ParseArticulationName( uslotVisuals );

                if( !TryGetIntElement( uslotVisuals, "symbol", out var articulationSymbol ) )
                {
                    articulationSymbol.Value = ArticulationSymbol.Default.Value;
                }

                var type = GetIntElement( uslotVisuals, "articulationtype" ).Value;
                var group = GetIntElement( uslotVisuals, "group" ).Value;

                var id = idGenerator.Next();

                var articulation = new Articulation(
                    id,
                    new ArticulationName( articulationName ),
                    new ArticulationSymbol( articulationSymbol.Value ),
                    EnumHelper.FromInt<ArticulationType>( type ),
                    new ArticulationGroup( group )
                );

                result.Articulations.Add( id, articulation );
            }

            foreach( var slot in objectElements )
            {
                var sv = Sv( slot );

                if( !USlotVisuals( sv, out var uslotVisuals ) )
                {
                    continue;
                }

                var articulationName = ParseArticulationName( uslotVisuals );
                var color = GetIntElement( slot, "color" ).Value;

                // Implement a Safe Mode..? or Everytime Clamp?
                // Some files over SoundSlotColorIndex.Max that created by Instrument developer
                // e.g. East West Quantum Leap
                //color = Math.Clamp( color, SoundSlotColorIndex.MinValue, SoundSlotColorIndex.MaxValue );

                var soundSlot = new SoundSlot(
                    new SoundSlotName( articulationName ),
                    new SoundSlotColorIndex( color ) );

                var refIdPairs =
                    result.Articulations.Where( x => x.Value.Name.Value == articulationName ).ToArray();

                foreach( var kvp in refIdPairs )
                {
                    soundSlot.ReferenceArticulationIds.Add( kvp.Key );
                }

                foreach( var midiMessage in MidiMessages( slot ) )
                {
                    var status = GetIntElement( midiMessage, "status" ).Value;
                    var data1 = GetIntElement( midiMessage, "data1" ).Value;
                    var data2 = GetIntElement( midiMessage, "data2" ).Value;

                    var mapping = new GenericMidiEvent(
                        new GenericMidiEventValue( status ),
                        new GenericMidiEventValue( data1 ),
                        new GenericMidiEventValue( data2 )
                    );
                    soundSlot.OutputMappings.Add( mapping );
                }

                result.SoundSlots.Add( soundSlot );
            }

            return result;
        }

        private static string ParseArticulationName( ObjectElement uslotVisuals )
        {
            var articulationName = GetStringElement( uslotVisuals, "text" ).Value;

            // If text attribute is empty (use a music symbol)
            if( string.IsNullOrEmpty( articulationName ) )
            {
                // Parse description attribute instead "text"
                articulationName = GetStringElement( uslotVisuals, "description" ).Value;

                // Both empty...
                if( string.IsNullOrEmpty( articulationName ) )
                {
                    articulationName = "UNKNOWN";
                }
            }

            return articulationName;
        }

        #region Parser
        private static MemberElement Slots( IEnumerable<MemberElement> xml )
        {
            foreach( var element in xml )
            {
                if( element.Name == "slots" )
                {
                    return element;
                }
            }
            throw new ElementNotFoundException( "slots" );
        }

        private static IEnumerable<ObjectElement> PSoundSlot( RootElement xml )
        {
            var result = new List<ObjectElement>();
            var slots = Slots( xml.Member );

            foreach( var listElement in slots.List )
            {
                foreach( var obj in listElement.Obj )
                {
                    if( obj.ClassName == "PSoundSlot" )
                    {
                        result.Add( obj );
                    }
                }
            }

            return result;
        }

        #region Not use (keep)
#if false
        private static IReadOnlyList<ObjectElement> SlotVisuals( RootElement xml )
        {
            var result = new List<ObjectElement>();

            foreach( var member in xml.Member )
            {
                if( member.Name == "slotvisuals" )
                {
                    var list = member.List;

                    foreach( var element in list )
                    {
                        foreach( var obj in element.Obj )
                        {
                            if( obj.ClassName == "USlotVisuals" )
                            {
                                result.Add( obj );
                            }
                        }
                    }
                }
            }

            return result;
        }
#endif
        #endregion

        private static MemberElement Sv( ObjectElement psoundSlot )
        {
            var sv = psoundSlot.Member.Where( o => o.Name == "sv" );
            var memberElements = sv as MemberElement[] ?? sv.ToArray();

            if( !memberElements.Any() )
            {
                throw new ElementNotFoundException( "sv" );
            }
            return memberElements.First();
        }

        private bool USlotVisuals( MemberElement sv, out ObjectElement target )
        {
            target = default!;

            foreach( var list in sv.List )
            {
                foreach( var obj in list.Obj )
                {
                    if( obj.ClassName == "USlotVisuals" )
                    {
                        target = obj;
                        return true;
                    }
                }
            }
            // "USlotVisuals" Not found (== Warn: Slot has found, but this slot is not assigned to articulation.)
            return false;
        }

        private static IEnumerable<ObjectElement> MidiMessages( ObjectElement psoundSlot )
        {
            var result = new List<ObjectElement>();

            foreach( var obj in psoundSlot.Obj )
            {
                if( obj.ClassName != "PSlotMidiAction" )
                {
                    continue;
                }

                foreach( var member in obj.Member )
                {
                    if( member.Name != "midiMessages" )
                    {
                        continue;
                    }

                    foreach( var i in member.List )
                    {
                        foreach( var midi in i.Obj )
                        {
                            if( midi.ClassName == "POutputEvent" )
                            {
                                result.Add( midi );
                            }
                        }
                    }
                }
            }

            return result;
        }


        private static IntElement GetIntElement( ObjectElement obj, string name )
        {
            foreach( var i in obj.Int )
            {
                if( i.Name == name )
                {
                    return i;
                }
            }
            throw new ElementNotFoundException( $"{obj.ClassName}.int" );

        }

        private static bool TryGetIntElement( ObjectElement obj, string name, out IntElement target )
        {
            target = default!;
            foreach( var i in obj.Int )
            {
                if( i.Name == name )
                {
                    target = i;
                    return true;
                }
            }

            return false;
        }


        private static StringElement GetStringElement( ObjectElement obj, string name )
        {
            foreach( var i in obj.String )
            {
                if( i.Name == name )
                {
                    return i;
                }
            }

            throw new ElementNotFoundException( $"{obj.ClassName}.string" );
        }

        private static bool TryGetStringElement( ObjectElement obj, string name, out StringElement target )
        {
            target = default!;
            foreach( var i in obj.String )
            {
                if( i.Name == name )
                {
                    target = i;
                    return true;
                }
            }

            return false;
        }

        #endregion Parser

    }
}