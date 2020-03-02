using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Controllers.DTO.Request
{
    public class CompanyAddOtherAddress
    {
        [Required]
        public string Address { get; set; }
    }
}
