using System;
using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public class GenericCell<T> : Cell
    {
        public new T Value { get; }

        public GenericCell( [AllowNull] T value ) : base( value )
        {
            Value = value ?? throw new ArgumentNullException();
        }
    }
}