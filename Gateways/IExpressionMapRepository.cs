using ArticulationUtility.Entities.VSTExpressionMap;

namespace ArticulationUtility.Gateways
{
    public interface IExpressionMapRepository :
        IDataLoader<ExpressionMap>,
        IDataSaver<ExpressionMap>
    {
    }
}