using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace JuniperWebAPI.Models.Response
{
    public class TaxRate
    {
        public TaxRate()
        {
            this.rate = new Rate();
        }
        public class Rate
        {
            public string Zip { get; set; }
            public string Country { get; set; }
            public string Country_Rate { get; set; }
            public string State { get; set; }
            public string State_Rate { get; set; }
            public string County { get; set; }
            public string County_Rate { get; set; }
            public string City { get; set; }
            public string City_Rate { get; set; }
            public string Combined_District_Rate { get; set; }
            public string Combined_Rate { get; set; }
            public bool Freight_Taxable { get; set; }
        }
        public Rate rate { get; set; }
        
    }
}
