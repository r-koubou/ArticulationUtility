using ArticulationUtility.Controllers;
using ArticulationUtility.Controllers.Converting;
using ArticulationUtility.UseCases.Converting;

namespace ConvertingAppLauncher
{
    public interface ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request );
        public IFileConvertingRequest CreateRequest()
            => new FileConvertingRequest();
    }
}