namespace ArticulationUtility.Controllers.Converting
{
    public interface IConvertingController<TRequest>
    {
        public void Convert( TRequest request );
    }
}