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

        [HttpGet]
        [Route("/{id}/contacts")]
        public async Task<ActionResult<DTO.Response.Contact[]>> GetAllCompanyContactsAsync(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            var allCompanyEmployees = (await _companyService.GetAllEmployeesOfCompanyAsync(id))
                .Select(e => _mapper.Map<DTO.Response.Contact>(e));
            var allCompanyFreelancers = (await _companyService.GetAllFreelancersOfCompanyAsync(id))
                .Select(f => _mapper.Map<DTO.Response.Contact>(f));
            var allCompanyContacts = allCompanyEmployees.Concat(allCompanyFreelancers);

            return Ok(allCompanyContacts);
        }

        [HttpGet]
        [Route("/{id}/employees")]
        public async Task<ActionResult<DTO.Response.Employee[]>> GetAllCompanyEmployeesAsync(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            var allCompanyEmployees = await _companyService.GetAllEmployeesOfCompanyAsync(id);

            return Ok(allCompanyEmployees.Select(e => _mapper.Map<DTO.Response.Employee>(e)));
        }

        [HttpGet]
        [Route("/{id}/freelancers")]
        public async Task<ActionResult<DTO.Response.Freelancer[]>> GetAllCompanyFreelancersAsync(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            var allCompanyFreelancers = await _companyService.GetAllFreelancersOfCompanyAsync(id);

            return Ok(allCompanyFreelancers.Select(f => _mapper.Map<DTO.Response.Freelancer>(f)));
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task<ActionResult<DTO.Response.Company>> UpdateCompanyAsync(int id, [FromBody] CompanyUpdate newCompanyData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var company = await _companyService.GetCompanyAsync(id);

            if (company is null)
                return NotFound($"No company with id '{id}' exists");

            await _companyService.UpdateCompanyAsync(id, newCompanyData);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompanyAsync([FromBody] CompanyCreation newCompanyData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCompany = await _companyService.CreateCompanyAsync(newCompanyData);

            return Created($"/companies/{createdCompany.Id}", _mapper.Map<DTO.Response.Company>(createdCompany));
        }
    }
}
