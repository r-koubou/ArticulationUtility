namespace ArticulationUtility.Gateways.Common
{
    public interface IFileSaver<T> : IDataSaver<T>
    {
        public string SavePath { get; set; }
    }
}