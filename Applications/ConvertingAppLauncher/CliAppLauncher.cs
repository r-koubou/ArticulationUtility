using CommandLine;

namespace ConvertingAppLauncher
{
    public class CliAppLauncher
    {
        protected CommandlineOption Option { get; }

        public bool ParsedArguments { get; }

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

        public void Execute( ICliApplication application )
        {
            if( !ParsedArguments )
            {
                return;
            }

            foreach( var inputFile in Option.InputFilesByWildCard )
            {
                var request = application.CreateRequest();
                request.InputFile       = inputFile;
                request.OutputDirectory = Option.OutputDirectory;

                var controller = application.GetController( request );
                controller.Convert( request );
            }
        }
    }
}