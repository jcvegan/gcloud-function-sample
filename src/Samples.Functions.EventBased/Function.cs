using CloudNative.CloudEvents;
using Google.Cloud.Functions.Framework;
using Google.Events.Protobuf.Cloud.PubSub.V1;
using Microsoft.Extensions.Logging;
using Samples.Functions.EventBased.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.Functions.EventBased
{
    //[FunctionsStartup(typeof(Startup))]
    public class Function : ICloudEventFunction<MessagePublishedData>
    {
        //private readonly ICountryApi _countryApi;
        private readonly ILogger<Function> _logger;

        public Function(/*ICountryApi countryApi,*/ ILogger<Function> logger)
        {
            //_countryApi = countryApi;
            _logger = logger;
        }

        public async Task HandleAsync(CloudEvent cloudEvent, MessagePublishedData data, CancellationToken cancellationToken)
        {
            var decodedMessage = data.Message.TextData;

            Console.WriteLine("Storage object information:");
            Console.WriteLine("CloudEvent information:");
            Console.WriteLine($"  ID: {cloudEvent.Id}");
            Console.WriteLine($"  Source: {cloudEvent.Source}");
            Console.WriteLine($"  Type: {cloudEvent.Type}");
            Console.WriteLine($"  Subject: {cloudEvent.Subject}");
            Console.WriteLine($"  DataSchema: {cloudEvent.DataSchema}");
            Console.WriteLine($"  DataContentType: {cloudEvent.DataContentType}");
            Console.WriteLine($"  Time: {cloudEvent.Time?.ToUniversalTime():yyyy-MM-dd'T'HH:mm:ss.fff'Z'}");
            Console.WriteLine($"  SpecVersion: {cloudEvent.SpecVersion}");

            //await _countryApi.GetCountryInfoAsync(decodedMessage);
        }
    }
}
