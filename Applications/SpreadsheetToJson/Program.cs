using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.Interactors.Converting.Json.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace SpreadsheetToJson
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

            var loadRepository = SpreadsheetVersionDetector.DetectRepository( launcher.Option.InputFileName );
            var saveRepository = new JsonFileRepository();

            var useCase = new ConvertingToJsonInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}