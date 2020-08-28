using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Presenters
{
    public class ConsoleTextPresenter : ITextPresenter
    {
        public void Progress( string message )
        {
            Console.WriteLine( $"Converting: {message}" );
        }
    }
}