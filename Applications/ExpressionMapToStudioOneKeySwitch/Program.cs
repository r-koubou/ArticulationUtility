using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromVSTExpressionMap;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace ExpressionMapToStudioOneKeySwitch
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var loadRepository = new ExpressionMapFileRepository();
            var saveRepository = new KeySwitchFileRepository();
            var useCase = new ConvertingToStudioOneKeySwitchFileInteractor( loadRepository, saveRepository );
            return  new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}