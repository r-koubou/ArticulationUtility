using System;

namespace ArticulationUtility.Gateways.Json.ForVSTExpressionMap
{
    public class JsonRepository : IJsonRepository
    {
        private string Path { get; }
        public JsonRepository( string path )
        {
            Path = path ?? throw new ArgumentNullException( nameof( path ) );
        }

        public UseCases.Values.Json.ForVSTExpressionMap.JsonRoot Load()
        {
            throw new System.NotImplementedException();
        }
    }
}