using System;
using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Json.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;

namespace ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet
{
    public class ConvertingToJsonInteractor : IFileConvertingInteractor<Workbook, JsonRoot>
    {
        public IFileRepository<Workbook> SourceRepository { get; }

        public IFileRepository<JsonRoot> TargetRepository { get; }

        public ITextPresenter Presenter { get; }

        public ConvertingToJsonInteractor(
            IFileRepository<Workbook> loadRepository,
            IFileRepository<JsonRoot> saveRepository,
            ITextPresenter presenter )
        {
            SourceRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            TargetRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
            Presenter        = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert( IFileConvertingRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var workbook = SourceRepository.Load();
            var toExpressionMapAdaptor = new WorkbookTranslator();
            var toJsonAdaptor = new ExpressionMapTranslator();

            var expressionMaps = toExpressionMapAdaptor.Translate( workbook );

            foreach( var expressionMap in expressionMaps )
            {
                var json = toJsonAdaptor.Translate( expressionMap );

                Presenter.Progress( json.Info.Name );

                json.Info.Description = "Converted from spreadsheet";

                TargetRepository.SavePath = Path.Combine(
                    request.OutputDirectory,
                    json.Info.Name + TargetRepository.Suffix
                );
                TargetRepository.Save( json );
            }
        }
    }
}