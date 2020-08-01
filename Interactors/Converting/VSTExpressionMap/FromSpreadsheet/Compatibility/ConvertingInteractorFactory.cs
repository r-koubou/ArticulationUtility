using System;

using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using InteractorVer_0_7 = ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7.ConvertingToExpressionMapInteractor;
using InteractorVer_0_8 = ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8.ConvertingToExpressionMapInteractor;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility
{
    public static class ConvertingInteractorFactory
    {
        public class InteractorNotFoundException : Exception
        {
            public InteractorNotFoundException( SpreadsheetVersion version ) : base( version.ToString() )
            {}
        }

        public static IConvertingUseCase<ConvertingFileFormatRequest> Create( string spreadSheetFilePath )
        {
            var version = SpreadsheetVersionDetector.Detect( spreadSheetFilePath );

            return version switch
            {
                SpreadsheetVersion.Ver_0_7 => new InteractorVer_0_7(),
                SpreadsheetVersion.Ver_0_8 => new InteractorVer_0_8(),
                _                          => throw new InteractorNotFoundException( version )
            };
        }
    }
}