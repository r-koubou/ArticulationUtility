using System;

using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7;
using ArticulationUtility.Interactors.Converting.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Controllers.Testing
{
    [TestFixture]
    public class ConvertingControllerTest
    {

        [Test]
        public void ConvertTest()
        {
            var convertingUseCase = new ConvertingToExpressionMapInteractor();
            var controller = new ConvertingController( convertingUseCase );
            var request = new FileConvertingRequest();
            request.InputFile = "#";
            request.OutputDirectory = ".";
            controller.Convert( request );
        }
    }

    public interface IConvertingController<in TRequest>
    {
        void Convert( TRequest request );
    }

    public class ConvertingController : IConvertingController<FileConvertingRequest>
    {
        private IConvertingUseCase<FileConvertingRequest> UseCase { get; }

        public ConvertingController( IConvertingUseCase<FileConvertingRequest> useCase )
        {
            UseCase = useCase ?? throw new ArgumentNullException( nameof( useCase ) );
        }

        public void Convert( FileConvertingRequest request )
        {
            UseCase.Convert( request );
        }
    }

}