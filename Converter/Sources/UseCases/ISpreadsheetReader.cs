using System.Collections.Generic;

using VSTExpressionMap.Core.Entities.ExpressionMaps;

namespace VSTExpressionMap.Core.UseCases
{
    public interface ISpreadsheetReader
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}