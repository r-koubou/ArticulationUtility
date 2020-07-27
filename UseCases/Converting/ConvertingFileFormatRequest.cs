namespace ArticulationUtility.UseCases.Converting
{
    public class ConvertingFileFormatRequest
    {
        public string InputFile { get; set; }
        public string OutputDirectory { get; set; } = ".";
    }
}