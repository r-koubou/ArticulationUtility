using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Presenters
{
    public class ConsoleProgressPresenter : IConvertingProgressPresenter<string>
    {

        public void StartConverting( string message )
        {
            Console.WriteLine( message );
        }

        public void EndConverting( string message )
        {
            Console.WriteLine( message );
        }

        public void Progress( string message )
        {
            Console.WriteLine( message );
        }
    }
}