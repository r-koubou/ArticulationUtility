namespace ArticulationUtility.Gateways.Common
{
    public interface IDataLoader<T>
    {
        public T Load();
    }
}