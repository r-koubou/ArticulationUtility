using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Entities.VSTExpressionMap;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Adapters.VSTExpressionMap
{
    public class WorkbookAdapter : IExpressionMapAdapter
    {
        private Workbook Workbook { get; }

        public WorkbookAdapter( Workbook workbook )
        {
            Workbook = workbook ?? throw new ArgumentNullException( nameof( workbook ) );
        }
        public List<ExpressionMap> Convert()
        {
            var result = new List<ExpressionMap>();

            foreach( var worksheet in Workbook.Worksheets )
            {
                var expressionMap = new ExpressionMap( new ExpressionMapName( worksheet.OutputNameCell.Value ) );
                result.Add( expressionMap );
            }

            throw new NotImplementedException();
            return result;
        }
    }
}