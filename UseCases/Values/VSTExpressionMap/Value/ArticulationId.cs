using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    public class ArticulationId : IEquatable<ArticulationId>
    {
        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue - 1;

        private static int _incrementalCount;

        public int Value { get; }

        static ArticulationId()
        {
            Reset();
        }

        public static void Reset( int initialId = 0 )
        {
            _incrementalCount = initialId;
        }

        public static ArticulationId Increment()
        {
            if( _incrementalCount == int.MaxValue )
            {
                throw new OverflowException();
            }

            var id = new ArticulationId( _incrementalCount );
            _incrementalCount++;

            return id;
        }

        public ArticulationId( int id )
        {
            RangeValidateHelper.ValidateIntRange( id, MinValue, MaxValue );
            Value = id;
        }

        public bool Equals( ArticulationId other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}