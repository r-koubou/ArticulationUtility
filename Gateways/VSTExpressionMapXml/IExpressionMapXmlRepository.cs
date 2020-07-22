using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public interface IExpressionMapXmlRepository :
        IDataLoader<InstrumentMapElement>,
        IDataSaver<InstrumentMapElement>
    {
        const string Suffix = "expressionmap";
    }
}