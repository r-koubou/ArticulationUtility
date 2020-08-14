using CommandLine;

namespace ConvertingAppLauncher
{
    public class CommandlineOption
    {
        private const string HelpInputFileName = "Filename for converting";
        private const string HelpOutputDirectory = "Output directory";

        [Option( 'i', "input", Required = true, HelpText = HelpInputFileName )]
        public string InputFileName { get; set; } = string.Empty;

        [Option( 'o', "outputdir", Required = true, HelpText = HelpOutputDirectory )]
        public string OutputDirectory { get; set; } = string.Empty;

    }
}