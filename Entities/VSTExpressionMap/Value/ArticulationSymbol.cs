using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    public class ArticulationSymbol
    {
        public const int MinValue = 0;
        public const int MaxValue = int.MaxValue - 1;

        private static readonly ArticulationSymbol _default = new ArticulationSymbol( MinValue );
        public static ArticulationSymbol Default => _default;

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