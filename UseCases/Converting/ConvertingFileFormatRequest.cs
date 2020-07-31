namespace ArticulationUtility.UseCases.Converting
{
    public class ConvertingFileFormatRequest
    {
        public string InputFile { get; set; } = string.Empty;
        public string OutputDirectory { get; set; } = ".";
    }
}