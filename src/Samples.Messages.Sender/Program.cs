// See https://aka.ms/new-console-template for more information
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.Http;
using CloudNative.CloudEvents.SystemTextJson;
using Samples.Messages.Sender;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://127.0.0.1:8080");
var countryName = "Canadá";
var data = new  CountryRequest() { 
    Message = new CountryRequestMessage(){
        Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(countryName)),
        Attributes = new Dictionary<string, string>()
    },
    Subscription = "AnySubscription"
};

var cloudEvent = new CloudEvent()
{
    Id = Guid.NewGuid().ToString(),
    Type = "google.pubsub.topic.publish",
    DataContentType = "application/json",
    Data = data,
    Source = new Uri("https://domain.com"),
    Time = DateTimeOffset.Now,
};

var content = cloudEvent.ToHttpContent(ContentMode.Structured, new JsonEventFormatter(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }, new JsonDocumentOptions()));

await httpClient.PostAsync("", content);