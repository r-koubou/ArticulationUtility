namespace ArticulationUtility.UseCases.Converting
{
    public class FileConvertingRequest : IFileConvertingRequest
    {
        public string InputFile { get; set; } = string.Empty;
        public string OutputDirectory { get; set; } = ".";
    }
}