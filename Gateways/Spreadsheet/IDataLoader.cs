namespace ArticulationUtility.Gateways.Spreadsheet
{
    public interface IDataLoader<T>
    {
        public T Load();
    }
}