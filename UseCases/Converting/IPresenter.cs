namespace ArticulationUtility.UseCases.Converting
{
    public interface IPresenter<in TMessage>
    {
        public void Progress( TMessage message );
    }
}