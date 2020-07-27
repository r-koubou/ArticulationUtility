namespace ArticulationUtility.Gateways
{
    public interface IFileRepository<T> : IRepository<T>
    {
        public string Suffix { get; }
        public string LoadPath { get; set; }
        public string SavePath { get; set; }
    }
}