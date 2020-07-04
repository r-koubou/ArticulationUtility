using System.Collections.Generic;

using Spreadsheet2Expressionmap.Converter.Entities.ExpressionMaps;

namespace Spreadsheet2Expressionmap.Converter.Controllers
{
    public interface ISpreadsheetReader
    {
        public IReadOnlyList<ExpressionMap> Read();
    }
}