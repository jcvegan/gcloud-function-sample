using System.Threading.Tasks;

namespace Samples.Contracts
{
    public interface ICountryApi
    {
        Task<object> GetCountryInfo(string countryName);
    }
}
