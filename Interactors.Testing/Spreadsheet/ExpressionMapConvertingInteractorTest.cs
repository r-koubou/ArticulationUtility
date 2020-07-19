using System;
using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap;
using ArticulationUtility.Adapters.VSTExpressionMap.Compat.Ver_0_7;
using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Entities.VSTExpressionMap;
using ArticulationUtility.Gateways.Spreadsheet;
using ArticulationUtility.Gateways.Spreadsheet.Compat.Ver_0_7;
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
            var adapter = new WorkbookAdapter();
            var presenter = new ConsolePresenter( Console.Out );
            var interactor = new SpreadsheetConvertingInteractor(
                expressionMapRepository,
                adapter,
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
        private IExpressionMapAdapter<Workbook> Adapter { get; }
        public SpreadsheetConvertingInteractor(
            ISpreadsheetRepository expressionMapRepository,
            IExpressionMapAdapter<Workbook> adapter,
            IExpressionMapPresenter presenter )
        {
            SpreadsheetRepository = expressionMapRepository ?? throw new ArgumentNullException( nameof( expressionMapRepository ) );
            Adapter               = adapter ?? throw new ArgumentNullException( nameof( adapter ) );
            Presenter             = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert()
        {
            var book = SpreadsheetRepository.Load();
            var expressionMap = Adapter.Convert( book );
        }
    }
}