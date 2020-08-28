namespace ArticulationUtility.UseCases.Converting
{
    public interface IConvertingProgressPresenter<in TMessage>
    {
        public void Progress( TMessage message );
    }
}