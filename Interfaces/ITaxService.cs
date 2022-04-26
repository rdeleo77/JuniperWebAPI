using JuniperWebAPI.Models.Request;
using JuniperWebAPI.Models.Response;

namespace JuniperWebAPI.Interfaces
{
    public interface ITaxService
    {
        public Task<TaxRate> GetRates(string zipCode);

        public Task<Taxes> CalculateTaxes(TaxRequest taxRequest);
    }
}
