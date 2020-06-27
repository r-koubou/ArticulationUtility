using System;

namespace Spreadsheet2Expressionmap.Converter.Entity.Value
{
    /// <summary>
    /// A Slot name
    /// </summary>
    public class SlotName : IEquatable<SlotName>
    {
        private string Name { get; }

        public SlotName( string name )
        {
            if( string.IsNullOrEmpty( name ) || name.Trim().Length == 0 )
            {
                throw new System.ArgumentException( $"{nameof(name)} is null or empty" );
            }
            Name = name;
        }

        public bool Equals( SlotName other )
        {
            if( other == null )
            {
                return false;
            }

            return other.Name == Name;
        }

        public override string ToString() => Name;
    }
}
