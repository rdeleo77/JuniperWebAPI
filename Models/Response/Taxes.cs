namespace JuniperWebAPI.Models.Response
{
    public class Taxes
    {
        public Taxes()
        {
            this.tax = new Tax();
        }

        public class Tax
        {
            public Tax()
            {
                Jurisdictions = new Jurisdiction();
            }
            public float Order_Total_Amount { get; set; }
            public float Shipping { get; set; }
            public float Taxable_Amount { get; set; }
            public float Amount_To_Collect { get; set; }
            public float Rate { get; set; }
            public bool Has_Nexus { get; set; }
            public bool Freight_Taxable { get; set; }
            public string Tax_Source { get; set; }
            public string Exemption_Type { get; set; }
            public Jurisdiction Jurisdictions { get; set; }
        }

        public class Jurisdiction
        {
            public string Country { get; set; }
            public string State { get; set; }
            public string County { get; set; }
            public string City { get; set; }
        }

        public Tax tax { get; set; }
    }
}
