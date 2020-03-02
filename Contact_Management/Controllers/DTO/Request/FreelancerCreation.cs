using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Controllers.DTO.Request
{
    public class FreelancerCreation : ContactCreation
    {
        [Required]
        public string VATIdNumber { get; set; }
    }
}
