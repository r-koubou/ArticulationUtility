using ArticulationUtility.Gateways.Spreadsheet.VSTExpressionMap.Compatibility.Ver_0_7;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.Spreadsheet
{
    [TestFixture]
    public class SpreadsheetRepositoryTest
    {
        [Test]
        public void LoadTest()
        {
            var repository = new SpreadsheetRepository( "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" );
            var workbook = repository.Load();

            Assert.IsNotNull( workbook );
        }
    }
}