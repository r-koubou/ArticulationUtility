namespace ArticulationUtility.Gateways
{
    public interface IRepository<T>
    {
        public T Load();
        public void Save( T data );
    }
}