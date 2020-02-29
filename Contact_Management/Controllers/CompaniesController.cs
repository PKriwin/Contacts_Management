using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Management.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<ActionResult<DTO.Response.Company>> GetCompanyAsync(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            return Ok(_mapper.Map<DTO.Response.Company>(company));
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Response.Company[]>> GetAllCompaniesAsync()
        {
            var companies = (await _companyService.GetAllCompaniesAsync())
                .Select(c => _mapper.Map<DTO.Response.Company>(c))
                .ToArray();

            return Ok(companies);
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task<ActionResult<DTO.Response.Company>> UpdateCompanyAsync(int id, [FromBody] CompanyUpdate newCompanyData)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            await _companyService.UpdateCompanyAsync(id, newCompanyData);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompanyAsync([FromBody] CompanyCreation newCompanyData)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(newCompanyData);

            return Created($"/companies/{createdCompany.Id}", _mapper.Map<DTO.Response.Company>(createdCompany));
        }
    }
}
