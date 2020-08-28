using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers.Converting
{
    public class ConvertingFileFormatController : IConvertingFileFormatController
    {
        public IConvertingProgressPresenter<IFileConvertingRequest> Presenter { get; }

        private IFileConvertingUseCase UseCase { get; }

        public ConvertingFileFormatController(
            IFileConvertingUseCase useCase,
            IConvertingProgressPresenter<IFileConvertingRequest> presenter )
        {
            UseCase   = useCase ?? throw new ArgumentNullException( nameof( useCase ) );
            Presenter = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert( IFileConvertingRequest request )
        {
            Presenter.Progress( request );
            UseCase.Convert( request );
        }
    }
}