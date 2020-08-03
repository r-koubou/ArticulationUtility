using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8.Value
{
    public class OutputNameCell : IEquatable<OutputNameCell>
    {
        public static readonly OutputNameCell Empty = new OutputNameCell();
        public string Value { get; }

        private OutputNameCell()
        {
            Value = string.Empty;
        }

        public OutputNameCell( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }

            Value = name;
        }

        public bool Equals( [AllowNull] OutputNameCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;

    }
}