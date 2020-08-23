using System;

using ArticulationUtility.Gateways.Translating.Tsv;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

using Translator_Version_0_7 = ArticulationUtility.FileAccessors.Spreadsheet.Compatibility.Ver_0_7.TsvTranslator;
using Translator_Version_0_8 = ArticulationUtility.FileAccessors.Spreadsheet.Compatibility.Ver_0_8.TsvTranslator;


namespace ArticulationUtility.FileAccessors.Spreadsheet.Compatibility
{
    public static class TsvTranslatorFactory
    {
        public static ITsvTranslator<Worksheet> Create( SpreadsheetVersion version )
        {
            switch( version )
            {
                case SpreadsheetVersion.Ver_0_7:
                    return new Translator_Version_0_7();
                case SpreadsheetVersion.Ver_0_8:
                    return new Translator_Version_0_8();
                default:
                    throw new ArgumentException( $"Translator for `{version}` not found");
            }
        }

    }
}