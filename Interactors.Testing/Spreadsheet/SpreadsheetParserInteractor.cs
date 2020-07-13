using System;
using System.Collections.Generic;

using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Gateways;
using ArticulationUtility.UseCases.Spreadsheet;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Spreadsheet
{
    [TestFixture]
    public class SpreadsheetParserInteractorTest
    {

        [Test]
        public void ParseTest()
        {
            var repository = new VSTExpressionMapSheetRepository();
            var parser = new SpreadsheetParserInteractor( repository );
            parser.Parse();
        }
    }

    public class SpreadsheetParserInteractor : ISpreadsheetParseUseCase
    {
        private ISpreadsheetRepository Repository { get; }

        public SpreadsheetParserInteractor( ISpreadsheetRepository repository )
        {
            Repository = repository ?? throw new ArgumentNullException( nameof( repository ) );
        }
        public IReadOnlyList<Row> Parse()
        {
            return Repository.Load();
        }
    }
}