using Microsoft.Extensions.Logging;
using Samples.Contracts;
using System.Threading.Tasks;

namespace Samples.Services
{
    public class CountryApi : ICountryApi
    {
        private readonly ILogger<CountryApi> _logger;

        public CountryApi(ILogger<CountryApi> logger)
        {
            _logger = logger;
        }

        public async Task<object> GetCountryInfo(string countryName)
        {
            _logger.LogInformation(countryName);

            return Task.FromResult(countryName);
        }
    }
}
