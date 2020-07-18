namespace ArticulationUtility.Gateways
{
    public interface IDataLoader<T>
    {
        public T Load();
    }
}