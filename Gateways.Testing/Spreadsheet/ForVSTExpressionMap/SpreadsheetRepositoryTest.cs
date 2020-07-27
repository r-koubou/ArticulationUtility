using ArticulationUtility.Gateways.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7;

using NUnit.Framework;

namespace ArticulationUtility.Gateways.Testing.Spreadsheet.ForVSTExpressionMap
{
    [TestFixture]
    public class SpreadsheetRepositoryTest
    {
        [Test]
        public void LoadTest()
        {
            var repository = new SpreadsheetFileRepository(){ LoadPath = "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" };
            var workbook = repository.Load();

            Assert.IsNotNull( workbook );
        }
    }
}