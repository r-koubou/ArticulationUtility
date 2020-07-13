using System;

using ArticulationUtility.Entities.Spreadsheet;
using ArticulationUtility.Gateways;
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
            var expressionMapRepository = new ExpressionMapRepository();
            var presenter = new ConsolePresenter( Console.Out );
            var interactor = new SpreadsheetConvertingInteractor(
                expressionMapRepository,
                presenter
            );

            interactor.Convert( workbook);
        }
    }

    public class SpreadsheetConvertingInteractor : ISpreadsheetConvertingUseCase
    {
        private IExpressionMapRepository ExpressionMapRepository { get; }
        private IConvertingPresenter Presenter { get; }

        public SpreadsheetConvertingInteractor(
            IExpressionMapRepository expressionMapRepository,
            IConvertingPresenter presenter )
        {
            ExpressionMapRepository = expressionMapRepository ?? throw new ArgumentNullException( nameof( expressionMapRepository ) );
            Presenter               = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert( Workbook workbook )
        {
            throw new NotImplementedException();
        }
    }
}