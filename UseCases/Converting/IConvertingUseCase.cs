namespace ArticulationUtility.UseCases.Converting
{
    public interface IConvertingUseCase<in TRequest>
    {
        public void Convert( TRequest request );
    }
}