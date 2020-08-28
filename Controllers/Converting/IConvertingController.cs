namespace ArticulationUtility.Controllers.Converting
{
    public interface IConvertingController<in TRequest>
    {
        void Convert( TRequest request );
    }
}