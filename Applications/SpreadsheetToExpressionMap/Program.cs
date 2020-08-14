using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Spreadsheet.ForVSTExpressionMap;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace SpreadsheetToExpressionMap
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var loadRepository = SpreadsheetVersionDetector.DetectRepository( request.InputFile );
            var saveRepository = new ExpressionMapFileRepository();
            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}