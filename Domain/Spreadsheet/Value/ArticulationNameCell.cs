using System;

using ArticulationUtility.Domain.Helper;

namespace ArticulationUtility.Domain.Spreadsheet.Value
{
    public class ArticulationNameCell : IEquatable<ArticulationNameCell>
    {
        public string Value { get; }

        public ArticulationNameCell( string name )
        {
            if( StringHelper.IsNullOrTrimEmpty( name ) )
            {
                throw new InvalidNameException( nameof( name ) );
            }

            Value = name;
        }

        public bool Equals( ArticulationNameCell other )
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