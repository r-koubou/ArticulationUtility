using ArticulationUtility.Controllers;
using ArticulationUtility.Controllers.Converting;
using ArticulationUtility.FileAccessors.Spreadsheet;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromSpreadsheet;
using ArticulationUtility.Presenters;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace SpreadsheetToExpressionMap
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var presenter = new ConsoleTextPresenter();
            var loadRepository = new SpreadsheetFileRepository();
            var saveRepository = new ExpressionMapFileRepository();
            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository, presenter );

            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}