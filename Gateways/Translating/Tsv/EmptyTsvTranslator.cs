using System.Collections.Generic;

using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.Gateways.Translating.Tsv
{
    public class EmptyTsvTranslator : ITsvTranslator<Workbook>
    {
        public List<TsvData> Translate( Workbook source )
            => new List<TsvData>();
    }
}