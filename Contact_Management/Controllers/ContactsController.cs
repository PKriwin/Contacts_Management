using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Management.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Response.Contact[]>> GetAllContactsAsync()
        {
            var allEmployeesContacts = (await _contactService.GetAllEmployeesAsync())
                .Select(e => _mapper.Map<DTO.Response.Contact>(e));
            var allFreelancersContacts = (await _contactService.GetAllFreelancersAsync())
                .Select(f => _mapper.Map<DTO.Response.Contact>(f));
            var allContacts = allEmployeesContacts.Concat(allFreelancersContacts)
                .OrderBy(c => c.Id).ToArray();

            return Ok(allContacts);
        }

        [HttpGet]
        [Route("/employees")]
        public async Task<ActionResult<DTO.Response.Employee[]>> GetAllEmployeesAsync()
        {
            var allEmployees = (await _contactService.GetAllEmployeesAsync())
                .Select(e => _mapper.Map<DTO.Response.Employee>(e))
                .ToArray();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("/employees/{id}")]
        public async Task<ActionResult<DTO.Response.Employee>> GetEmployeeAsync(int id)
        {
            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            return Ok(_mapper.Map<DTO.Response.Employee>(employee));
        }

        [HttpGet]
        [Route("/freelancers")]
        public async Task<ActionResult<DTO.Response.Freelancer[]>> GetAllFreelancersAsync()
        {
            var allFreelancers = (await _contactService.GetAllFreelancersAsync())
                .Select(f => _mapper.Map<DTO.Response.Freelancer>(f))
                .ToArray();

            return Ok(allFreelancers);
        }

        [HttpGet]
        [Route("/freelancers/{id}")]
        public async Task<ActionResult<DTO.Response.Freelancer>> GetFreelancerAsync(int id)
        {
            var freelancer = await _contactService.GetFreelancerAsync(id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{id}' exists");

            return Ok(_mapper.Map<DTO.Response.Freelancer>(freelancer));
        }

        [HttpPost]
        [Route("/employees")]
        public async Task<ActionResult<DTO.Response.Employee>> CreateEmployeeAsync([FromBody] EmployeeCreation newEmployeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEmployee = await _contactService.CreateEmployeeAsync(newEmployeeData);

            return Created($"contacts/employees/{newEmployee.Id}", _mapper.Map<DTO.Response.Employee>(newEmployee));
        }

        [HttpPost]
        [Route("/freelancers")]
        public async Task<ActionResult<DTO.Response.Employee>> CreateFreelancerAsync([FromBody] FreelancerCreation newFreelancerData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newFreelancer = await _contactService.CreateFreelancerAsync(newFreelancerData);

            return Created($"contacts/freelancers/{newFreelancer.Id}", _mapper.Map<DTO.Response.Freelancer>(newFreelancer));
        }

        [HttpPut]
        [Route("/employees/{id}")]
        public async Task<ActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeUpdate newEmployeeData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            await _contactService.UpdateEmployeeAsync(id, newEmployeeData);

            return Ok();
        }

        [HttpPut]
        [Route("/freelancers/{id}")]
        public async Task<ActionResult> UpdateFreelancerAsync(int id, [FromBody] FreelancerUpdate newFreelancerData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var freelancer = await _contactService.GetFreelancerAsync(id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{id}' exists");

            await _contactService.UpdateFreelancerAsync(id, newFreelancerData);

            return Ok();
        }

        [HttpDelete]
        [Route("/employees/{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            await _contactService.DeleteEmployeeAsync(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/freelancers/{id}")]
        public async Task<ActionResult> DeleteFreelancerAsync(int id)
        {
            var freelancer = await _contactService.GetFreelancerAsync(id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{id}' exists");

            await _contactService.DeleteFreelancerAsync(id);

            return Ok();
        }
    }
}
