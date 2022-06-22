using Microsoft.Extensions.Logging;
using Samples.Functions.EventBased.Contracts;
using System.Threading.Tasks;

namespace Samples.Functions.EventBased.Services
{
    public class CountryApi : ICountryApi
    {
        private readonly ILogger<CountryApi> _logger;

        public CountryApi(ILogger<CountryApi> logger)
        {
            _logger = logger;
        }

        public async Task<object> GetCountryInfoAsync(string countryName)
        {
            _logger.LogInformation(countryName);

            return await Task.FromResult(countryName);
        }
    }
}
