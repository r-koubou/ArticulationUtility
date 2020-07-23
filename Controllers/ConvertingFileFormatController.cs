using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers
{
    public class ConvertingFileFormatController : IConvertingController<ConvertingFileFormatRequest>
    {
        private IConvertingUseCase<ConvertingFileFormatRequest> UseCase { get; }

        public ConvertingFileFormatController( IConvertingUseCase<ConvertingFileFormatRequest> useCase )
        {
            UseCase = useCase ?? throw new ArgumentNullException( nameof( useCase ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            UseCase.Convert( request );
        }
    }
}