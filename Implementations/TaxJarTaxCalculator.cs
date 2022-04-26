using System.Net.Http.Headers;
using System.Text.Json;
using JuniperWebAPI.Interfaces;
using JuniperWebAPI.Models.Request;
using JuniperWebAPI.Models.Response;

namespace JuniperWebAPI.Implementations
{
    public class TaxJarTaxCalculator : ITaxCalculator
    {
        private readonly string _token;

        public TaxJarTaxCalculator(IConfiguration configuration)
        {
            _token = configuration.GetSection("TaxJarAPIToken").Value;
        }
        public async Task<TaxRate> GetRates(string zipCode)
        {
            _ = zipCode ?? throw new ArgumentNullException(nameof(zipCode));

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token=\"{_token}\"");
                var result = await httpClient.GetAsync($"https://api.taxjar.com/v2/rates/{zipCode}");

                var rates = JsonSerializer.Deserialize<TaxRate>(await result.Content.ReadAsStreamAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return rates;
            }
        }

        public async Task<Taxes> CalculateTaxes(TaxRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token=\"{_token}\"");

                var serializedRequest = JsonSerializer.Serialize(request);
                var content = new StringContent(serializedRequest);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await httpClient.PostAsync("https://api.taxjar.com/v2/taxes/", content);
                var taxes = JsonSerializer.Deserialize<Taxes>(await result.Content.ReadAsStreamAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return taxes;
            }
        }
    }
}
