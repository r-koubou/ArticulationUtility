using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers
{
    public class ConvertingFileFormatController : IConvertingFileFormatController
    {
        private IConvertingUseCase<IFileConvertingRequest> UseCase { get; }

        public ConvertingFileFormatController( IConvertingUseCase<IFileConvertingRequest> useCase )
        {
            UseCase = useCase ?? throw new ArgumentNullException( nameof( useCase ) );
        }

        public void Convert( IFileConvertingRequest request )
        {
            UseCase.Convert( request );
        }
    }
}