using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace ExpressionMapToJson
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new JsonFileRepository();
            var useCase = new ConvertingToJsonInteractor( loadRepository, saveRepository );

            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}