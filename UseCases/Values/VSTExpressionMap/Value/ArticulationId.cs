using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    public class ArticulationId : IEquatable<ArticulationId>
    {
        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue - 1;

        public int Value { get; }

        public ArticulationId( int id )
        {
            RangeValidateHelper.ValidateIntRange( id, MinValue, MaxValue );
            Value = id;
        }

        public bool Equals( [AllowNull] ArticulationId other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}