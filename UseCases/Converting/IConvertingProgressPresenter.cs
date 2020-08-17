namespace ArticulationUtility.UseCases.Converting
{
    public interface IConvertingProgressPresenter<TMessage>
    {
        public void StartConverting( TMessage message );
        public void EndConverting( TMessage message );
        public void Progress( TMessage message );
    }
}