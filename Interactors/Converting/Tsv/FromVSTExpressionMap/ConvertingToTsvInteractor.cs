using System.IO;

using ArticulationUtility.Entities.Tsv.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Tsv;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.Tsv.FromVSTExpressionMap
{
    public class ConvertingToTsvInteractor : IFileConvertingUseCase
    {
        private IFileRepository<RootElement> LoadRepository { get; }

        private IFileRepository<TsvData> SaveRepository { get; }

        private ITsvTranslator<ExpressionMap> TsvTranslator { get; }

        public ConvertingToTsvInteractor(
            IFileRepository<RootElement> loadRepository,
            IFileRepository<TsvData> saveRepository,
            ITsvTranslator<ExpressionMap> tsvTranslator )
        {
            LoadRepository = loadRepository;
            SaveRepository = saveRepository;
            TsvTranslator  = tsvTranslator;
        }

        public void Convert( IFileConvertingRequest request )
        {
            LoadRepository.LoadPath = request.InputFile;

            var rootElement = LoadRepository.Load();
            var expressionMapXmlTranslator = new ExpressionMapXmlTranslator();
            var expressionMap = expressionMapXmlTranslator.Translate( rootElement );

            var tsvList = TsvTranslator.Translate( expressionMap );

            var i = 0;
            foreach( var tsv in tsvList )
            {
                SaveRepository.SavePath = Path.Combine(
                    request.OutputDirectory,
                    expressionMap.Name.Value + ( i > 0 ? $"_{i}" : string.Empty ) + SaveRepository.Suffix
                );
                SaveRepository.Save( tsv );
                i++;
            }
        }
    }
}