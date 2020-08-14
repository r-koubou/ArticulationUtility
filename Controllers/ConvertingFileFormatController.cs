using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers
{
    public class ConvertingFileFormatController : IConvertingFileFormatController
    {
        private IFileConvertingUseCase UseCase { get; }

        public ConvertingFileFormatController( IFileConvertingUseCase useCase )
        {
            UseCase = useCase ?? throw new ArgumentNullException( nameof( useCase ) );
        }

        public void Convert( IFileConvertingRequest request )
        {
            UseCase.Convert( request );
        }
    }
}