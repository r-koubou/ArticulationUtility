using System.Collections.Generic;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps;

namespace Spreadsheet2Expressionmap.Converter.Gateways
{
    public interface ISpreadsheetReader
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}