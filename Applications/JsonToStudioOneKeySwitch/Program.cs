using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromJson;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace JsonToStudioOneKeySwitch
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
            var saveRepository = new KeySwitchFileRepository();

            var useCase = new ConvertingToStudioOneKeySwitchFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}