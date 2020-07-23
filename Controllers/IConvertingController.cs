namespace ArticulationUtility.Controllers
{
    public interface IConvertingController<in TRequest>
    {
        void Convert( TRequest request );
    }
}