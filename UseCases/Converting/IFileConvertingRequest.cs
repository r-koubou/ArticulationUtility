namespace ArticulationUtility.UseCases.Converting
{
    public interface IFileConvertingRequest
    {
        public string InputFile { get; set; }
        public string OutputDirectory { get; set; }
    }
}