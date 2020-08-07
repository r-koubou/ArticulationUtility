namespace ArticulationUtility.Gateways.Translating
{
    public interface IDataTranslator<in TSource, out TTarget>
    {
        TTarget Translate( TSource source );
    }
}