using ArticulationUtility.Controllers;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

namespace ConvertingAppLauncher
{
    public class CliAppLauncher
    {
        private CommandlineOption Option { get; }

        private bool ParsedArguments { get; }

        public CliAppLauncher( string[] args )
        {
            ParsedArguments = ParseCommandlineOption( args, out var option );
            Option          = option;
        }

        private bool ParseCommandlineOption( string[] args, out CommandlineOption target )
        {
            target = default!;

            var result = Parser.Default.ParseArguments<CommandlineOption>( args );

            if( result.Tag == ParserResultType.NotParsed )
            {
                return false;
            }

            var parsed = (Parsed<CommandlineOption>)result;
            target = parsed.Value;

            return true;
        }

        public void Execute(
            IConvertingFileFormatController controller,
            IFileConvertingRequest request )
        {
            if( !ParsedArguments )
            {
                return;
            }

            request.InputFile       = Option.InputFileName;
            request.OutputDirectory = Option.OutputDirectory;

            controller.Convert( request );

        }
    }
}