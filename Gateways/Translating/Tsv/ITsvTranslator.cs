using System.Collections.Generic;

using ArticulationUtility.Entities.Tsv.Aggregate;

namespace ArticulationUtility.Gateways.Translating.Tsv
{
    public interface ITsvTranslator<in TSource> : IDataTranslator<TSource, List<TsvData>>
    {}
}