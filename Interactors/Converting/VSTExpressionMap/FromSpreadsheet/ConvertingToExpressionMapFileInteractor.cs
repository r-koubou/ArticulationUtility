using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.Gateways.Translating.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet
{
    public class ConvertingToExpressionMapFileInteractor : IFileConvertingInteractor<Workbook, RootElement>
    {
        public IFileRepository<Workbook> SourceRepository { get; }
        public IFileRepository<RootElement> TargetRepository { get; }
        public ITextPresenter Presenter { get; }

        public ConvertingToExpressionMapFileInteractor(
            IFileRepository<Workbook> sourceRepository,
            IFileRepository<RootElement> targetRepository,
            ITextPresenter presenter )
        {
            SourceRepository = sourceRepository;
            TargetRepository = targetRepository;
            Presenter        = presenter;
        }

        public void Convert( IFileConvertingRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var workbook = SourceRepository.Load();
            var workBookAdapter = new WorkbookTranslator();
            var expressionMapAdapter = new ExpressionMapTranslator();

            SourceRepository.LoadPath = request.InputFile;

            foreach( var expressionMap in workBookAdapter.Translate( workbook ) )
            {
                foreach( var xml in expressionMapAdapter.Translate( expressionMap ) )
                {
                    Presenter.Progress( expressionMap.Name.Value );

                    TargetRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + TargetRepository.Suffix
                    );
                    TargetRepository.Save( xml );
                }
            }
        }
    }
}