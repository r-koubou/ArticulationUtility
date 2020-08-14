using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace ExpressionMapToStudioOneKeySwitch
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
            var saveRepository = new KeySwitchFileRepository();

            var useCase = new ConvertingToStudioOneKeySwitchFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}