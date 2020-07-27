using System;

using ArticulationUtility.Utilities;

namespace ArticulationUtility.UseCases.Values.VSTExpressionMap.Value
{
    public class ArticulationIdGenerator
    {
        private const int Default = 0;
        private const int Limit = int.MaxValue;

        private int Id { get; set; }

        public ArticulationIdGenerator( int defaultId = Default )
        {
            RangeValidateHelper.ValidateIntRange( defaultId, Default, Limit - 1 );
            Id = defaultId;
        }

        public void Reset()
        {
            Id = Default;
        }

        public ArticulationId Next()
        {
            if( Id == Limit )
            {
                throw new OverflowException( "Id increments will be overflow" );
            }

            var result = new ArticulationId( Id );
            Id++;

            return result;
        }
    }
}