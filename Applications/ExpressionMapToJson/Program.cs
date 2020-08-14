using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.Json.FromVSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace ExpressionMapToJson
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );

            if( !launcher.ParsedArguments )
            {
                return;
            }

            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new JsonFileRepository();

            var useCase = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}