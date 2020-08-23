using System.Collections.Generic;

using ArticulationUtility.Entities.Tsv.Aggregate;

namespace ArticulationUtility.Gateways.Translating.Tsv
{
    public interface ITsvTranslator<in T> : IDataTranslator<T, List<TsvData>>
    {}
}