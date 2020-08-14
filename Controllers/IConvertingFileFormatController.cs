using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers
{
    public interface IConvertingFileFormatController
        : IConvertingController<IFileConvertingRequest>
    {}
}