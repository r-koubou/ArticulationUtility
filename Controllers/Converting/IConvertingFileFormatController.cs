using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers.Converting
{
    public interface IConvertingFileFormatController
        : IConvertingController<IFileConvertingRequest>
    {}
}