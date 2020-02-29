using System.Collections.Generic;

namespace Contact_Management.Controllers.DTO.Request
{
    public class CompanyUpdate
    {
        public string Name { get; set; }
        public string VATIdNumber { get; set; }
        public string HeadQuarterAddress { get; set; }
        public List<string> OtherAdresses { get; set; }
    }
}
