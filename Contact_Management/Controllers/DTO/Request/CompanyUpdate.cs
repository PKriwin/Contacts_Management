using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Controllers.DTO.Request
{
    public class CompanyUpdate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VATIdNumber { get; set; }
        [Required]
        public string HeadQuarterAddress { get; set; }
        public List<string> OtherAdresses { get; set; } = new List<string>();
    }
}
