using System;
using System.IO;

using ArticulationUtility.Adapters.VSTExpressionMap.FromJson;
using ArticulationUtility.Adapters.VSTExpressionMapXml.FromVSTExpressionMap;
using ArticulationUtility.Gateways.Json.NewtonsoftJson;
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
            var expressionMapAdapter = new ExpressionMapAdapter();

            foreach( var expressionMap in jsonAdapter.Convert( json ) )
            {
                foreach( var xml in expressionMapAdapter.Convert( expressionMap ) )
                {
                    SaveRepository.SavePath = Path.Combine(
                        request.OutputDirectory,
                        expressionMap.Name.Value + "." + IExpressionMapXmlRepository.Suffix
                    );
                    SaveRepository.Save( xml.RootElement );
                }
            }
        }
    }
}