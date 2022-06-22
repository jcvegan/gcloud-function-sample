namespace Samples.Messages.Sender
{
    public class CountryRequest
    {
        public CountryRequestMessage Message { get; set; }
        public string Subscription { get; set; }
    }
    public class CountryRequestMessage
    {
        public string Data { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
    }
}
