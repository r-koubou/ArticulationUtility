using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Controllers.Converting
{
    public interface IConvertingController<TRequest>
    {
        public IConvertingProgressPresenter<TRequest> Presenter { get; }
        public void Convert( TRequest request );
    }
}