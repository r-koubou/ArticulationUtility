using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;

using CommandLine;

using ConvertingAppLauncher;

namespace SpreadsheetToExpressionMap
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
            var saveRepository = new ExpressionMapFileRepository();

            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            var controller = new ConvertingFileFormatController( useCase );
            var request = new FileConvertingRequest();

            launcher.Execute( controller, request );

        }
    }
}