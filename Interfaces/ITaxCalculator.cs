using JuniperWebAPI.Models.Request;
using JuniperWebAPI.Models.Response;

namespace JuniperWebAPI.Interfaces
{
    public interface ITaxCalculator
    {
        public Task<TaxRate> GetRates(string zipCode);

        public Task<Taxes> CalculateTaxes(TaxRequest taxRequest);
    }
}
