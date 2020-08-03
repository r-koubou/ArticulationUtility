using System;
using System.Diagnostics.CodeAnalysis;

using ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value;
using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap
{
    public class ArticulationNameCell : IEquatable<ArticulationNameCell>
    {
        public static readonly ArticulationNameCell Empty
            = new ArticulationNameCell( CellConstants.NotAvailableCellValue );
        public string Value { get; }

        public ArticulationNameCell( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }

            Value = name;
        }

        public bool Equals( [AllowNull] ArticulationNameCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;

    }
}