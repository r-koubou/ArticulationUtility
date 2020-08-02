using System.IO;

using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7
{
    [TestFixture]
    public class SpreadsheetRepositoryTest
    {
        private static readonly string TestDataDir
            = Path.Combine( TestContext.CurrentContext.TestDirectory, "TestFiles" );

        [Test]
        public void LoadTest()
        {
            var repository = new SpreadsheetFileRepository
            {
                LoadPath = Path.Combine( TestDataDir, @"Sample_Ver_0_7.xlsx" )
            };
            var workbook = repository.Load();

            Assert.IsNotNull( workbook );
        }
    }
}