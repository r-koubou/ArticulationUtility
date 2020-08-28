using ArticulationUtility.Controllers;
using ArticulationUtility.Controllers.Converting;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.FileAccessors.Tsv;
using ArticulationUtility.Gateways.Translating.Tsv.FromVSTExpressionMap;
using ArticulationUtility.Interactors.Converting.Tsv.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace ExpressionMapToTsv
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var tsvTranslator = new TsvTranslator();
            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new TsvFileRepository();
            var useCase = new ConvertingToTsvInteractor( loadRepository, saveRepository, tsvTranslator );

            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}