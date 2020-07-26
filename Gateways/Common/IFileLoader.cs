namespace ArticulationUtility.Gateways.Common
{
    public interface IFileLoader<T> : IDataLoader<T>
    {
        public string LoadPath { get; set; }
    }
}