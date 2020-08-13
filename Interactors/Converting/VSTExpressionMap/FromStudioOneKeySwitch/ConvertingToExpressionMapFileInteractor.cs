using System.IO;

using ArticulationUtility.Gateways;
using ArticulationUtility.Gateways.Translating.StudioOneKeySwitch.FromStudioOneKeySwitchXml;
using ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromStudioOneKeySwitch;
using ArticulationUtility.Gateways.Translating.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using ExpressionMapRootElement = ArticulationUtility.UseCases.Values.VSTExpressionMapXml.RootElement;
using StudioOneRootElement = ArticulationUtility.UseCases.Values.StudioOneKeySwitchXml.RootElement;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromStudioOneKeySwitch
{
    public class ConvertingToExpressionMapFileInteractor : IFileConvertingInteractor<StudioOneRootElement, ExpressionMapRootElement>
    {
        public IFileRepository<StudioOneRootElement> SourceRepository { get; }

        public IFileRepository<ExpressionMapRootElement> TargetRepository { get; }

        public ConvertingToExpressionMapFileInteractor(
            IFileRepository<StudioOneRootElement> loadRepository,
            IFileRepository<ExpressionMapRootElement> saveRepository )
        {
            SourceRepository = loadRepository;
            TargetRepository = saveRepository;
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            SourceRepository.LoadPath = request.InputFile;

            var xml = SourceRepository.Load();
            var studioOneKeySwitchXmlTranslator = new StudioOneKeySwitchXmlTranslator();
            var expressionMapTranslator = new StudioOneKeySwitchTranslator();
            var expressionMapXmlTranslator = new ExpressionMapTranslator();

            var studioOneKeySwitch = studioOneKeySwitchXmlTranslator.Translate( xml );
            {
                foreach( var expressionMap in expressionMapTranslator.Translate( studioOneKeySwitch ) )
                {
                    foreach( var expressionMapXml in expressionMapXmlTranslator.Translate( expressionMap ) )
                    {
                        TargetRepository.SavePath = Path.Combine(
                            request.OutputDirectory,
                            expressionMapXml.StringElement.Value + TargetRepository.Suffix
                        );
                        TargetRepository.Save( expressionMapXml );
                    }
                }
            }
        }
    }
}