using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromStudioOneKeySwitch;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace StudioOneKeySwitchToExpressionMap
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

            var loadRepository = new KeySwitchFileRepository();
            var saveRepository = new ExpressionMapFileRepository();

            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}