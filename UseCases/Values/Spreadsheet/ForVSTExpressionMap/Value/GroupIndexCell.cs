using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Value
{
    public class GroupIndexCell : IEquatable<GroupIndexCell>
    {
        public const int MinValue = 0;
        public const int MaxValue = 3;
        public static readonly GroupIndexCell Default = new GroupIndexCell( MinValue );

        public int Value { get; }

        public GroupIndexCell( int index )
        {
            RangeValidateHelper.ValidateIntRange( index, MinValue, MaxValue );
            Value = index;
        }

        public bool Equals( [AllowNull] GroupIndexCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value.ToString();
    }
}