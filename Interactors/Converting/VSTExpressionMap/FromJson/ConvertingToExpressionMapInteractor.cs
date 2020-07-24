using System;

using ArticulationUtility.Adapters.VSTExpressionMap.FromJson;
using ArticulationUtility.Gateways.Json.ForVSTExpressionMap;
using ArticulationUtility.Gateways.VSTExpressionMapXml;
using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson
{
    public class ConvertingToExpressionMapInteractor : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        private IJsonRepository LoadRepository { get; }

        private IExpressionMapXmlRepository SaveRepository { get; }

        public ConvertingToExpressionMapInteractor( IJsonRepository loadRepository, IExpressionMapXmlRepository saveRepository )
        {
            LoadRepository = loadRepository ?? throw new ArgumentNullException( nameof( loadRepository ) );
            SaveRepository = saveRepository ?? throw new ArgumentNullException( nameof( saveRepository ) );
        }

        public void Convert( ConvertingFileFormatRequest request )
        {
            var json = LoadRepository.Load();
            var jsonAdapter = new JsonAdapter();

            foreach( var expressionMap in jsonAdapter.Convert( json ) )
            {

            }
            throw new System.NotImplementedException();
        }
    }
}