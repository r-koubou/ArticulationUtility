using System.IO;

using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Tsv;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Tsv.FromSpreadsheet
{
    public class ConvertingToTsvInteractor : IFileConvertingUseCase
    {
        private IFileRepository<Workbook> LoadRepository { get; }

        private IFileRepository<TsvData> SaveRepository { get; }

        private ITsvTranslator<Worksheet> TsvTranslator { get; }

        public ConvertingToTsvInteractor(
            IFileRepository<Workbook> loadRepository,
            IFileRepository<TsvData> saveRepository,
            ITsvTranslator<Worksheet> tsvTranslator )
        {
            LoadRepository = loadRepository;
            SaveRepository = saveRepository;
            TsvTranslator  = tsvTranslator;
        }

        public void Convert( IFileConvertingRequest request )
        {
            LoadRepository.LoadPath = request.InputFile;

            var workbook = LoadRepository.Load();

            foreach( var sheet in workbook.Worksheets )
            {
                var tsvList = TsvTranslator.Translate( sheet );

                foreach( var tsv in tsvList )
                {
                    SaveRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        sheet.Name + SaveRepository.Suffix
                    );
                    SaveRepository.Save( tsv );
                }
            }
        }
    }
}