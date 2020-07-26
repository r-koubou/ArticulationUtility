using ArticulationUtility.Controllers;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_8;
using ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace SpreadsheetToJson
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

            var loadRepository = new SpreadsheetRepository();
            var saveRepository = new JsonRepository();
            loadRepository.LoadPath = option.InputFileName;

            var useCase = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new ConvertingFileFormatRequest();

            request.InputFile       = option.InputFileName;
            request.OutputDirectory = option.OutputDirectory;

            controller.Convert( request );
        }
    }
}