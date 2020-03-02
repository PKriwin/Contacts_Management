using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Controllers.DTO.Request
{
    public class FreelancerUpdate : ContactUpdate
    {
        [Required]
        public string VATIdNumber { get; set; }
    }
}
