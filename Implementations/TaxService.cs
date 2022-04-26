using JuniperWebAPI.Interfaces;
using JuniperWebAPI.Models.Request;
using JuniperWebAPI.Models.Response;

namespace JuniperWebAPI.Implementations
{
    public class TaxService : ITaxService
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _ = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));

            // instead of injecting tax calculator, you could inject a locator that would allow
            // multiple implementations as described in the word document.
            _taxCalculator = taxCalculator;
        }

        public async Task<TaxRate> GetRates(string zipCode)
        {
            return await _taxCalculator.GetRates(zipCode);
        }

        public async Task<Taxes> CalculateTaxes(TaxRequest taxRequest)
        {
            return await _taxCalculator.CalculateTaxes(taxRequest);
        }
    }
}
