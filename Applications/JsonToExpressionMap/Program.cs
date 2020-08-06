using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessing.Json.Articulation;
using ArticulationUtility.FileAccessing.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace JsonToExpressionMap
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "JSON filename for convert";
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
            var result = Parser.Default.ParseArguments<CommandlineOption>( args );

            if( result.Tag == ParserResultType.NotParsed )
            {
                return;
            }

            var parsed = (Parsed<CommandlineOption>)result;
            var option = parsed.Value;

            var loadRepository = new JsonFileRepository();
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