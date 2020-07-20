namespace ArticulationUtility.Gateways.Common
{
    public interface IDataSaver<T>
    {
        public void Save( T data );
    }
}