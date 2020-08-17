using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    public class ArticulationSymbol
    {
        public const int NoneValue = -1;

        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue - 1;

        public static ArticulationSymbol None => new ArticulationSymbol( MinValue );
        public int Value { get; }

        public ArticulationSymbol( int symbolId )
        {
            RangeValidateHelper.ValidateIntRange( symbolId, MinValue, MaxValue );
            Value = symbolId;
        }

        public bool Equals( [AllowNull] ArticulationId other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}