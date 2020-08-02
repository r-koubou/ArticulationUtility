using System.IO;

using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Converting.VSTExpressionMap.FromSpreadsheet.Compatibility.Ver_0_8
{
    [TestFixture]
    public class SpreadsheetConvertingInteractorTest
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
            var converter = new ConvertingToExpressionMapInteractor();
            var request = new ConvertingFileFormatRequest
            {
                InputFile       = Path.Combine( TestDataDir, @"Sample_Ver_0_8.xlsx" ),
                OutputDirectory = TestOutputDir
            };
            converter.Convert( request );
        }
    }
}