using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.Data.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public interface IExpressionMapXmlRepository :
        IDataLoader<InstrumentMapElement>,
        IDataSaver<InstrumentMapElement>
    {
    }
}