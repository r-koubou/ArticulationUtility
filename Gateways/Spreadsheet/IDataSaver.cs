namespace ArticulationUtility.Gateways
{
    public interface IDataSaver<T>
    {
        public void Save( T data );
    }
}