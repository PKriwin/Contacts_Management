using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Controllers.DTO.Request;
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
        private readonly IMapper _mapper;

        public CompaniesController(ILogger<ContactsController> logger, ICompanyService companyService, IMapper mapper)
        {
            _logger = logger;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/{Id}")]
        public async Task<ActionResult<DTO.Response.Company>> GetCompanyAsync(int Id)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            return Ok(_mapper.Map<DTO.Response.Company>(Company));
        }

        [HttpPut]
        [Route("/{Id}")]
        public async Task<ActionResult<DTO.Response.Company>> UpdateCompanyAsync(int Id, [FromBody] CompanyUpdate newCompanyData)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            await _companyService.UpdateCompanyAsync(Id, newCompanyData);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompanyAsync([FromBody] CompanyCreation newCompanyData)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(newCompanyData);

            return Created($"/companies/{createdCompany.Id}", _mapper.Map<DTO.Response.Company>(createdCompany));
        }

        [HttpPost]
        [Route("/{Id}/other_addresses")]
        public async Task<ActionResult> AddOtherAddressToCompanyAsync(int Id, [FromBody] CompanyAddOtherAddress newOtherAddressData)
        {
            var Company = await _companyService.GetCompanyAsync(Id);

            if (Company is null)
                return NotFound($"No company with id '{Id}' exists");

            await _companyService.AddOtherAddressToCompanyAsync(Id, newOtherAddressData.Address);

            return Ok();
        }
    }
}
