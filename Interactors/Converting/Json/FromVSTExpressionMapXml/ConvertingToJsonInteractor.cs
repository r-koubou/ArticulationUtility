using System;
using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.Json.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;
using ArticulationUtility.UseCases.Values.Json.ForArticulation;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml
{
    public class ConvertingToJsonInteractor : IFileConvertingInteractor<RootElement, JsonRoot>
    {
        public IFileRepository<RootElement> SourceRepository { get; }
        public IFileRepository<JsonRoot> TargetRepository { get; }
        public ITextPresenter Presenter { get; }

        public ConvertingToJsonInteractor(
            IFileRepository<RootElement> loadRepository,
            IFileRepository<JsonRoot> saveRepository,
            ITextPresenter presenter )
        {
            SourceRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            TargetRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
            Presenter        = presenter ?? throw new ArgumentNullException( nameof( presenter ) );
        }

        public void Convert( IFileConvertingRequest request )
        {
            var expressionMapAdapter = new ExpressionMapXmlTranslator();
            var jsonAdapter = new ExpressionMapTranslator();

            SourceRepository.LoadPath = request.InputFile;
            var xml = SourceRepository.Load();
            xml.StringElement.Value = Path.GetFileNameWithoutExtension( request.InputFile );

            var expressionMap = expressionMapAdapter.Translate( xml );

            Presenter.Progress( expressionMap.Name.Value );

            var json = jsonAdapter.Translate( expressionMap );
            json.Info.Description = "Converted from expressionmap";
            TargetRepository.SavePath = Path.Combine(
                request.OutputDirectory,
                Path.GetFileNameWithoutExtension( request.InputFile ) + TargetRepository.Suffix
            );
            TargetRepository.Save( json );
        }
    }
}