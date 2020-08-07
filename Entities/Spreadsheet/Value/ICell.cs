using System;

namespace ArticulationUtility.Entities.Spreadsheet.Value
{
    public interface ICell : IEquatable<ICell>
    {
        public object Value { get;  }
    }
}