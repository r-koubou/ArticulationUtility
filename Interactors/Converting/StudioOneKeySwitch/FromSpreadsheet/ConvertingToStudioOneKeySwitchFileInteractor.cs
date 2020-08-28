using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromSpreadsheet;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitchXml.FromStudioOneKeySwitch;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Spreadsheet.Aggregate;
using ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml;

namespace ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromSpreadsheet
{
    public class ConvertingToStudioOneKeySwitchFileInteractor : IFileConvertingInteractor<Workbook, RootElement>
    {
        public IFileRepository<Workbook> SourceRepository { get; }
        public IFileRepository<RootElement> TargetRepository { get; }
        public ITextPresenter Presenter { get; }

        public ConvertingToStudioOneKeySwitchFileInteractor(
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
            var workBookTranslator = new WorkbookTranslator();
            var keySwitchTranslator = new StudioOneKeySwitchTranslator();

            SourceRepository.LoadPath = request.InputFile;

            foreach( var expressionMap in workBookTranslator.Translate( workbook ) )
            {
                foreach( var xml in keySwitchTranslator.Translate( expressionMap ) )
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