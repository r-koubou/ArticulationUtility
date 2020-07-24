using System;

using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using InteractorVer_0_7 = ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7.ConvertingToExpressionMapInteractor;
using InteractorVer_0_8 = ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8.ConvertingToExpressionMapInteractor;

namespace SpreadsheetToExpressionMap
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

            switch( version )
            {
                case SpreadsheetVersion.Ver_0_7:
                    return new InteractorVer_0_7();
                case SpreadsheetVersion.Ver_0_8:
                    return new InteractorVer_0_8();
                default:
                    throw new InteractorNotFoundException( version );
            }
        }
    }
}