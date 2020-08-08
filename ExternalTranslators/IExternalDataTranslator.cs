namespace ArticulationUtility.ExternalTranslators
{
    public interface IExternalDataTranslator<in TSource, out TTarget>
    {
        TTarget Translate( TSource source );
    }
}