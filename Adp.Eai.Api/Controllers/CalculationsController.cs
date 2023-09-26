using Adp.Eai.Domain.Models;
using Adp.Eai.Domain.ViewModels;
using Adp.Eai.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Adp.Eai.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationsController : Controller
    {
        private readonly ILogger<CalculationsController> _logger;
        private readonly ICalculationService _service;

        public CalculationsController(ILogger<CalculationsController> logger, ICalculationService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get a new Calculation from external API, and return the instructions with result
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("GetCalculation")]
        public async Task<ActionResult<CalculationVM>> GetCalculationAsync() => Ok(await _service.GetCalculationResult());
    }
}
