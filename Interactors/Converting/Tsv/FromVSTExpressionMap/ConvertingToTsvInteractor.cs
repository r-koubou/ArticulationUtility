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
    public class ConvertingToTsvInteractor : IFileConvertingInteractor<RootElement, TsvData>
    {
        public IFileRepository<RootElement> SourceRepository { get; }

        public IFileRepository<TsvData> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        private ITsvTranslator<ExpressionMap> TsvTranslator { get; }

        public ConvertingToTsvInteractor(
            IFileRepository<RootElement> loadRepository,
            IFileRepository<TsvData> saveRepository,
            ITsvTranslator<ExpressionMap> tsvTranslator,
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

            var rootElement = SourceRepository.Load();
            var expressionMapXmlTranslator = new ExpressionMapXmlTranslator();
            var expressionMap = expressionMapXmlTranslator.Translate( rootElement );

            var tsvList = TsvTranslator.Translate( expressionMap );

            var i = 0;
            foreach( var tsv in tsvList )
            {
                Presenter.Progress( expressionMap.Name.Value );

                TargetRepository.SavePath = Path.Combine(
                    request.OutputDirectory,
                    expressionMap.Name.Value + ( i > 0 ? $"_{i}" : string.Empty ) + TargetRepository.Suffix
                );
                TargetRepository.Save( tsv );
                i++;
            }
        }
    }
}