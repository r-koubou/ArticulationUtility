using System.Collections.Generic;

namespace ArticulationUtility.UseCases
{
    public interface IConverter<TTarget>
    {
        public List<TTarget> Convert();
    }
}