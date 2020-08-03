using System.IO;

using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_7;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Controllers.Testing
{
    [TestFixture]
    public class ConvertingControllerTest
    {
        private static readonly string TestDataDir =
            Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                @"TestFiles/"
            );

        private static readonly string TestOutputDir = Path.Combine( TestDataDir, "out/" );

        [Test]
        public void ConvertTest()
        {
            var convertingUseCase = new ConvertingToExpressionMapInteractor();
            var controller = new ConvertingFileFormatController( convertingUseCase );
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = Path.Combine( TestDataDir, "Sample_Ver_0_7.xlsx" ),
                OutputDirectory = TestOutputDir
            };
            controller.Convert( request );
        }
    }
}