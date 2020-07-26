using ArticulationUtility.Gateways.Common;
using ArticulationUtility.UseCases.Values.VSTExpressionMapXml;

namespace ArticulationUtility.Gateways.VSTExpressionMapXml
{
    public interface IExpressionMapXmlRepository :
        IFileLoader<InstrumentMapElement>,
        IFileSaver<InstrumentMapElement>
    {
        const string Suffix = ".expressionmap";
    }
}