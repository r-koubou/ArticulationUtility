using System;
using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class Cell : ICell
    {
        public object Value { get; }

        public Cell( [AllowNull] object value )
        {
            Value = value ?? throw new ArgumentNullException();
        }

        public virtual bool Equals( [AllowNull] ICell other )
        {
            return other != null && other.Value == Value;
        }

        public  override string? ToString() => Value.ToString();
    }
}