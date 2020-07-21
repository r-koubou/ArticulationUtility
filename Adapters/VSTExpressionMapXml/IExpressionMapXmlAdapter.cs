using System.Collections.Generic;

using ArticulationUtility.UseCases.VSTExpressionMapXml;

namespace ArticulationUtility.Adapters.VSTExpressionMapXml
{
    public interface IExpressionMapXmlAdapter<in TSource>
    {
        List<InstrumentMapElement> Convert( TSource source );
    }
}