using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace ExpressionMapToStudioOneKeySwitch
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "Expressionmap filename for convert";
        private const string HelpOutputDirectory = "Output directory of *.keyswitch";

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
            var saveRepository = new KeySwitchFileRepository();

            var useCase = new ConvertingToStudioOneKeySwitchFileInteractor( loadRepository, saveRepository );
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