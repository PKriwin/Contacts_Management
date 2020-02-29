using System.Threading.Tasks;
using Contact_Management.Models;
using Contact_Management.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contact_Management.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly ICompanyService _companyService;

        public CompaniesController(ILogger<ContactsController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        [Route("/{Id}")]
        public async Task<ActionResult<Company>> GetCompanyAsync(int Id)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            return Ok(Company);
        }

        [HttpPut]
        [Route("/{Id}")]
        public async Task<ActionResult<Company>> UpdateCompanyAsync(int Id, [FromBody] Company newCompanyData)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            await _companyService.UpdateCompanyAsync(Id, newCompanyData);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompanyAsync([FromBody] Company newCompanyData)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(newCompanyData);

            return Created($"/companies/{createdCompany.Id}", createdCompany);
        }

        [HttpPost]
        [Route("/{Id}/other_addresses")]
        public async Task<ActionResult> AddOtherAddressToCompanyAsync(int Id, [FromBody] string Address)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            await _companyService.AddOtherAddressToCompanyAsync(Id, Address);

            return Ok();
        }
    }
}
