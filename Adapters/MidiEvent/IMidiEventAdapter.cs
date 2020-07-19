namespace ArticulationUtility.Adapters.MidiEvent
{
    public interface IMidiEventAdapter<in TSource, out TTarget>
    {
        TTarget Convert( TSource source );
    }
}