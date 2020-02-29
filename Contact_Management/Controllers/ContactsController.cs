using System.Threading.Tasks;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Models;
using Contact_Management.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contact_Management.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(ILogger<ContactsController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet]
        [Route("/employees/{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeeAsync(int id)
        {
            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            return Ok(employee);
        }

        [HttpGet]
        [Route("/freelancers/{Id}")]
        public async Task<ActionResult<Employee>> GetFreelancerAsync(int id)
        {
            var freelancer = await _contactService.GetFreelancerAsync(id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{id}' exists");

            return Ok(freelancer);
        }

        [HttpPost]
        [Route("/employees")]
        public async Task<ActionResult<Employee>> CreateEmployeeAsync([FromBody] EmployeeCreation newEmployeeData)
        {
            var newEmployee = await _contactService.CreateEmployeeAsync(newEmployeeData);

            return Created($"contacts/employees/{newEmployee.Id}", newEmployee);
        }

        [HttpPost]
        [Route("/freelancers")]
        public async Task<ActionResult<Employee>> CreateFreelancerAsync([FromBody] FreelancerCreation newFreelancerData)
        {
            var newFreelancer = await _contactService.CreateFreelancerAsync(newFreelancerData);

            return Created($"contacts/freelancer/{newFreelancer.Id}", newFreelancer);
        }

        [HttpPut]
        [Route("/employees/{Id}")]
        public async Task<ActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeUpdate newEmployeeData)
        {
            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            await _contactService.UpdateEmployeeAsync(id, newEmployeeData);

            return Ok();
        }

        [HttpPut]
        [Route("/freelancers/{Id}")]
        public async Task<ActionResult> UpdateFreelancerAsync(int id, [FromBody] FreelancerUpdate newFreelancerData)
        {
            var freelancer = await _contactService.GetFreelancerAsync(id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{id}' exists");

            await _contactService.UpdateFreelancerAsync(id, newFreelancerData);

            return Ok();
        }

        [HttpDelete]
        [Route("/employees/{Id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            var employee = await _contactService.GetEmployeeAsync(id);

            if (employee is null)
                return NotFound($"No employee with id '{id}' exists");

            await _contactService.DeleteEmployeeAsync(id);

            return Ok();
        }

        [HttpDelete]
        [Route("/freelancers/{Id}")]
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
