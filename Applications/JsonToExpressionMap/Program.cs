using System;

using ArticulationUtility.Controllers;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
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
        public string InputFileName { get; set; }

        [Option( 'o', "outputdir", Required = true, HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; }

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

            var useCase = new ConvertingToExpressionMapInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new ConvertingFileFormatRequest();

            request.InputFile       = option.InputFileName;
            request.OutputDirectory = option.OutputDirectory;

            controller.Convert( request );
        }
    }
}