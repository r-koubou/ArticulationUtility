using System;

namespace ArticulationUtility.Utilities
{
    public class NullOrEmptyException : Exception
    {
        public NullOrEmptyException()
        {}

        public NullOrEmptyException( string message ) : base( message )
        {}
    }
}