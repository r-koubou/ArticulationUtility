using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.Entities.VSTExpressionMap.Value
{
    /// <summary>
    /// A ExpressionMap name
    /// </summary>
    public class ExpressionMapName : IEquatable<ExpressionMapName>
    {
        public string Value { get; }

        public ExpressionMapName( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }
            Value = name;
        }

        public bool Equals( [AllowNull] ExpressionMapName other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;
    }
}
