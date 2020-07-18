using System;
using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap;
using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Entities.VSTExpressionMap;
using ArticulationUtility.Gateways.Spreadsheet;
using ArticulationUtility.Gateways.Spreadsheet.Ver_0_7;
using ArticulationUtility.Presenters;
using ArticulationUtility.UseCases.Converting;

using NUnit.Framework;

namespace ArticulationUtility.Interactors.Testing.Spreadsheet
{
    [TestFixture]
    public class ExpressionMapConvertingInteractorTest
    {

        [Test]
        public void ConvertingTest()
        {
            var workbook = new Workbook();
            var expressionMapRepository = new SpreadsheetRepository( "/Users/hiroaki/Develop/Project/OSS/ArticulationUtility/.temp/Template.xlsx" );
            var presenter = new ConsolePresenter( Console.Out );
            var interactor = new SpreadsheetConvertingInteractor(
                expressionMapRepository,
                presenter
            );

            interactor.Convert();
        }
    }

    public class ConsolePresenter : IExpressionMapPresenter, IDisposable
    {
        private TextWriter Writer { get; }
        public ConsolePresenter( TextWriter writer )
        {
            Writer = writer ?? throw new ArgumentNullException();
        }

        public void Dispose()
        {
            Writer.Flush();
            Writer.Dispose();
        }

        public void Present( ExpressionMap expressionMap )
        {
            throw new NotImplementedException();
        }
    }

    public class SpreadsheetConvertingInteractor : ISpreadsheetConvertingUseCase
    {
        private ISpreadsheetRepository SpreadsheetRepository { get; }
        private IExpressionMapPresenter Presenter { get; }

        public SpreadsheetConvertingInteractor(
            ISpreadsheetRepository expressionMapRepository,
            IExpressionMapPresenter presenter )
        {
            SpreadsheetRepository = expressionMapRepository ?? throw new ArgumentNullException( nameof( expressionMapRepository ) );
            Presenter             = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert()
        {
            var book = SpreadsheetRepository.Load();
            var adapter = new WorkbookAdapter( book );
            var expressionMap = adapter.Convert();
        }
    }
}