using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace JsonToExpressionMap
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

            var loadRepository = new JsonFileRepository();
            var saveRepository = new ExpressionMapFileRepository();

            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}