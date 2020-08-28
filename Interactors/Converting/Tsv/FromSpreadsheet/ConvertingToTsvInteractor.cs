using System.IO;

using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Tsv;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Tsv.FromSpreadsheet
{
    public class ConvertingToTsvInteractor : IFileConvertingInteractor<Workbook, TsvData>
    {
        public IFileRepository<Workbook> SourceRepository { get; }

        public IFileRepository<TsvData> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        private ITsvTranslator<Worksheet> TsvTranslator { get; }

        public ConvertingToTsvInteractor(
            IFileRepository<Workbook> loadRepository,
            IFileRepository<TsvData> saveRepository,
            ITsvTranslator<Worksheet> tsvTranslator,
            ITextPresenter presenter )
        {
            SourceRepository = loadRepository;
            TargetRepository = saveRepository;
            TsvTranslator    = tsvTranslator;
            Presenter        = presenter;
        }

        public void Convert( IFileConvertingRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var workbook = SourceRepository.Load();

            foreach( var sheet in workbook.Worksheets )
            {
                var tsvList = TsvTranslator.Translate( sheet );

                foreach( var tsv in tsvList )
                {
                    Presenter.Progress( sheet.Name );

                    TargetRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        sheet.Name + TargetRepository.Suffix
                    );
                    TargetRepository.Save( tsv );
                }
            }
        }
    }
}