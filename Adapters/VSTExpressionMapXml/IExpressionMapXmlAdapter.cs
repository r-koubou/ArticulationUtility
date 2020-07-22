using System.Collections.Generic;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml
{
    public interface IExpressionMapXmlAdapter<in TSource, TDest>
    {
        List<TDest> Convert( TSource source );
    }
}