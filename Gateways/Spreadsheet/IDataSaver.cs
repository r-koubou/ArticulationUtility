namespace ArticulationUtility.Gateways.Spreadsheet
{
    public interface IDataSaver<T>
    {
        public void Save( T data );
    }
}