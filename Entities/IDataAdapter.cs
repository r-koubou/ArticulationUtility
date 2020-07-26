namespace ArticulationUtility.Entities
{
    public interface IDataAdapter<in TSource, out TTarget>
    {
        TTarget Convert( TSource source );
    }
}