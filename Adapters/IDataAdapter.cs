namespace ArticulationUtility.Adapters
{
    public interface IDataAdapter<in TSource, out TTarget>
    {
        TTarget Convert( TSource source );
    }
}