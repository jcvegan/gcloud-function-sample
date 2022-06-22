using System.Threading.Tasks;

namespace Samples.Functions.EventBased.Contracts
{
    public interface ICountryApi
    {
        Task<object> GetCountryInfoAsync(string countryName);
    }
}
