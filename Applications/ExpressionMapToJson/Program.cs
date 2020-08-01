using ArticulationUtility.Controllers;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace ExpressionMapToJson
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "expressionmap filename for convert";
        private const string HelpOutputDirectory = "Output directory of *.json";

        [Option( 'i', "input", Required = true, HelpText = HelpInputFileName )]
        public string InputFileName { get; set; } = string.Empty;

        [Option( 'o', "outputdir", Required = true, HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; } = string.Empty;

    }
    public class Program
    {
        public static void Main( string[] args )
        {
            var result = Parser.Default.ParseArguments<CommandlineOption>( args );

            if( result.Tag == ParserResultType.NotParsed )
            {
                return;
            }

            var parsed = (Parsed<CommandlineOption>)result;
            var option = parsed.Value;

            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new JsonFileRepository();

            var useCase = new ConvertingToJsonInteractor( loadRepository, saveRepository );
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