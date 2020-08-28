using System;

using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Presenters
{
    public class ConsoleProgressPresenter : IConvertingProgressPresenter<IFileConvertingRequest>
    {
        public void Progress( IFileConvertingRequest message )
        {
            Console.WriteLine( $"Converting: {message.InputFile}" );
        }
    }
}