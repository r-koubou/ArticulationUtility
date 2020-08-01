using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
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

        public bool Equals( ExpressionMapName other )
        {
            return other.Value == Value;
        }

        public override string ToString() => Value;
    }
}
