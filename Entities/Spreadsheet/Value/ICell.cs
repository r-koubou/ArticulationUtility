using System;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public interface ICell : IEquatable<ICell>
    {
        public string Value { get;  }
        public void Accept( ICellVisitor visitor ) => visitor.Visit( this );
    }
}