using System.Collections.Generic;

using VSTExpressionMapTools.Domain.VSTExpressionMap;

namespace VSTExpressionMapTools.Application.Interfaces
{
    public interface IExpressionMapService
    {
        public IReadOnlyList<ExpressionMap> ExpressionMapList { get; protected set; }
        public void Write();
    }
}