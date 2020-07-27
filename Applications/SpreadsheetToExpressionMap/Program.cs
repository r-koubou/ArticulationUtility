using ArticulationUtility.Controllers;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace SpreadsheetToExpressionMap
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "Spreadsheet filename for convert";
        private const string HelpOutputDirectory = "Output directory of *.expressionmap";

        [Option( 'i', "input", Required = true, HelpText = HelpInputFileName )]
        public string InputFileName { get; set; }

        [Option( 'o', "outputdir", Required = true, HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; }

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

            var useCase = ConvertingInteractorFactory.Create( option.InputFileName );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new ConvertingFileFormatRequest();

            request.InputFile       = option.InputFileName;
            request.OutputDirectory = option.OutputDirectory;

            controller.Convert( request );
        }
    }
}