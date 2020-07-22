namespace ArticulationUtility.UseCases.Converting
{
    public class FileConvertingRequest
    {
        public string InputFile { get; set; }
        public string OutputDirectory { get; set; } = ".";
    }
}