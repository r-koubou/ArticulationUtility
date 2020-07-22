using System.Collections.Generic;

using ArticulationUtility.UseCases.VSTExpressionMapXml;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml
{
    public interface IExpressionMapXmlAdapter<in TSource, TDest>
    {
        List<TDest> Convert( TSource source );
    }
}