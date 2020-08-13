using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.MidiEvent.Value
{
    public abstract class MidiEventData : IMidiEventData, IEquatable<MidiEventData>
    {
        public int Value { get; }

        protected MidiEventData( int value )
        {
            Value = value;
        }

        protected MidiEventData( int value, int min, int max )
        {
            RangeValidateHelper.ValidateIntRange( value, min, max );
            Value = value;
        }

        public abstract override int GetHashCode();

        public static bool operator == ( MidiEventData a, MidiEventData b )
        {
            if( ReferenceEquals( a, null ) )
            {
                return ReferenceEquals( b, null );
            }
            return a.Equals( b );
        }

        public static bool operator != ( MidiEventData a, MidiEventData b )
        {
            if( ReferenceEquals( a, null ) )
            {
                return !ReferenceEquals( b, null );
            }
            return !a.Equals( b );
        }

        public override bool Equals( object? obj )
        {
            if( ReferenceEquals( null, obj ) )
            {
                return false;
            }

            if( ReferenceEquals( this, obj ) )
            {
                return true;
            }

            if( obj.GetType() != this.GetType() )
            {
                return false;
            }

            return Equals( (MidiEventData)obj );
        }

        public bool Equals( [AllowNull] MidiEventData other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();

    }
}