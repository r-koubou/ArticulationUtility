using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace SpreadsheetToExpressionMap
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "Spreadsheet filename for convert";
        private const string HelpOutputDirectory = "Output directory of *.expressionmap";

        [Option( 'i', "input", Required = true, HelpText = HelpInputFileName )]
        public string InputFileName { get; set; } = string.Empty;

        [Option( 'o', "outputdir", Required = true, HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; } = string.Empty;

    }
    public class Program
    {
        public static void Main( string[] args )
        {
            var result = (ParserResult<CommandlineOption>)Parser.Default.ParseArguments<CommandlineOption>(args);

            if( result.Tag == ParserResultType.NotParsed )
            {
                return;
            }

            var parsed = (Parsed<CommandlineOption>)result;
            var option = parsed.Value;

            var loadRepository = SpreadsheetVersionDetector.DetectRepository( option.InputFileName );
            var saveRepository = new ExpressionMapFileRepository();

            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = option.InputFileName,
                OutputDirectory = option.OutputDirectory
            };

            controller.Convert( request );
        }
    }
}