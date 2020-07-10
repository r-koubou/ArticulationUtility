using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;

namespace ArticulationUtility.UseCases.Spreadsheet
{
    public interface ISpreadsheetParseUseCase
    {
        public IReadOnlyList<SpreadsheetRow> Parse();
    }
}