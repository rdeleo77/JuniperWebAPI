using JuniperWebAPI.Interfaces;
using JuniperWebAPI.Models.Request;
using JuniperWebAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace JuniperWebAPI.Controllers
{
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxesController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet("[action]/{zipCode}")]
        public async Task<IActionResult> Rates([FromRoute] string zipCode)
        {
            TaxRate rate = await _taxService.GetRates(zipCode);
            return Ok(rate);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Taxes([FromQuery] TaxRequest taxRequest)
        {
            Taxes taxes = await _taxService.CalculateTaxes(taxRequest);
            return Ok(taxes);
        }
    }
}
