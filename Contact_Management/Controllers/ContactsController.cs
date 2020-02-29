using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contact_Management.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("ok");
        }
    }
}
