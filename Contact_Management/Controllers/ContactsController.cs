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
        public async Task<ActionResult<Employee>> GetEmployeeAsync(int Id)
        {
            var employee = await _contactService.GetEmployeeAsync(Id);

            if (employee is null)
                return NotFound($"No employee with id '{Id}' exists");

            return Ok(employee);
        }

        [HttpGet]
        [Route("/freelancers/{Id}")]
        public async Task<ActionResult<Employee>> GetFreelancerAsync(int Id)
        {
            var freelancer = await _contactService.GetFreelancerAsync(Id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{Id}' exists");

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
        public async Task<ActionResult> UpdateEmployeeAsync(int Id, [FromBody] EmployeeUpdate newEmployeeData)
        {
            var employee = await _contactService.GetEmployeeAsync(Id);

            if (employee is null)
                return NotFound($"No employee with id '{Id}' exists");

            await _contactService.UpdateEmployeeAsync(Id, newEmployeeData);

            return Ok();
        }

        [HttpPut]
        [Route("/freelancers/{Id}")]
        public async Task<ActionResult> UpdateFreelancerAsync(int Id, [FromBody] FreelancerUpdate newFreelancerData)
        {
            var freelancer = await _contactService.GetFreelancerAsync(Id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{Id}' exists");

            await _contactService.UpdateFreelancerAsync(Id, newFreelancerData);

            return Ok();
        }

        [HttpDelete]
        [Route("/employees/{Id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int Id)
        {
            var employee = await _contactService.GetEmployeeAsync(Id);

            if (employee is null)
                return NotFound($"No employee with id '{Id}' exists");

            await _contactService.DeleteEmployeeAsync(Id);

            return Ok();
        }

        [HttpDelete]
        [Route("/freelancers/{Id}")]
        public async Task<ActionResult> DeleteFreelancerAsync(int Id)
        {
            var freelancer = await _contactService.GetFreelancerAsync(Id);

            if (freelancer is null)
                return NotFound($"No freelancer with id '{Id}' exists");

            await _contactService.DeleteFreelancerAsync(Id);

            return Ok();
        }
    }
}
