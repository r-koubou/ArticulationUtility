using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public interface IExpressionMapXmlRepository :
        IDataLoader<InstrumentMapElement>,
        IDataSaver<InstrumentMapElement>
    {
    }
}