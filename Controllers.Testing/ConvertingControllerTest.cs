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
            var controller = new ConvertingFileFormatController( convertingUseCase );
            var request = new ConvertingFileFormatRequest();
            request.InputFile = "#";
            request.OutputDirectory = ".";
            controller.Convert( request );
        }
    }
}