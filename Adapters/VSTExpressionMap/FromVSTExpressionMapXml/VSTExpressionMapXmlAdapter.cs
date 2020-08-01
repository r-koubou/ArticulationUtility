using System.Collections.Generic;
using System.Linq;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.Adapters.VSTExpressionMap.FromVSTExpressionMapXml
{
    public class VSTExpressionMapXmlAdapter : IDataAdapter<RootElement, ExpressionMap>
    {
        public ExpressionMap Convert( RootElement source )
        {
            var result = new ExpressionMap( new ExpressionMapName( source.Name ) );
            var psoundSlot = PSoundSlot( source );

            var idGenerator = new ArticulationIdGenerator();

            foreach( var slot in psoundSlot )
            {
                var sv = Sv( slot );
                var uslotVisuals = USlotVisuals( sv );

                var articulationName = GetStringElement( uslotVisuals, "text" ).Value;
                var type = GetIntElement( uslotVisuals, "articulationtype" ).Value;
                var group = GetIntElement( uslotVisuals, "group" ).Value;

                var id = idGenerator.Next();

                var articulation = new Articulation(
                    id,
                    new ArticulationName( articulationName ),
                    EnumHelper.FromInt<ArticulationType>( type ),
                    new ArticulationGroup( group )
                );

                result.Articulations.Add( id, articulation );
            }

            foreach( var slot in psoundSlot )
            {
                var sv = Sv( slot );
                var uslotVisuals = USlotVisuals( sv );
                var articulationName = GetStringElement( uslotVisuals, "text" ).Value;

                var color = GetIntElement( slot, "color" ).Value;
                var soundSlot = new SoundSlot(
                    new SoundSlotName( articulationName ),
                    new SoundSlotColorIndex( color ) );

                var refIdPairs =
                    result.Articulations.Where( ( x ) => x.Value.Name.Value == articulationName ).ToArray();

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

        private static IReadOnlyList<ObjectElement> PSoundSlot( RootElement xml )
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

        private ObjectElement USlotVisuals( MemberElement sv )
        {
            foreach( var list in sv.List )
            {
                foreach( var obj in list.Obj )
                {
                    if( obj.ClassName == "USlotVisuals" )
                    {
                        return obj;
                    }
                }
            }
            throw new ElementNotFoundException( "USlotVisuals" );
        }

        private static IReadOnlyList<ObjectElement> MidiMessages( ObjectElement psoundSlot )
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

        private static StringElement GetStringElement( ObjectElement obj, string name )
        {
            foreach( var i in obj.String )
            {
                if( i.Name == name )
                {
                    return i;
                }
            }
            throw new ElementNotFoundException( $"{obj.ClassName}.int" );

        }

        #endregion Parser

    }
}